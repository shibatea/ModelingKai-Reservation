using System;
using Xunit;
using Reservation.Domain;
using Reservation.Domain.Reservations;
using Reservation.Domain.Reservations.MeetingRooms;
using Reservation.Domain.Reservations.Period;
using Reservation.Infrastructure;

namespace Test
{
    public class 予約希望RepositoryTest
    {
        [Fact]
        public void 予約希望をインスタンス化できること()
        {
            I予約希望Repository repository = new 予約希望Repository();

            Assert.NotNull(repository);
        }

        [Fact]
        public void 利用したい会議室が_先約がなければ_予約可能状態であることが分かる()
        {
            // ・予約可能かどうかが判定できる
            // 　・先約がなけれれば、予約可能ってわかる
            // 　・先約があるとkは、予約できないよ
            // 　・(他にも予約できない場合はあるかもしれないが、それはドメインエキスパートに聞こう！ 例えば、雨漏りがあって会議室が予約も使用もできないとか)

            I予約希望Repository repository = new 予約希望Repository();

            // TODO:trueを返すのはちょっと変
            var 予約したい期間 = new 予約期間(new 予約年月日(2020, 2, 10), 予約開始_時._12, 予約開始_分._00, new コマ数(8));
            var 予約希望 = new 予約希望(new MeetingRoom(MeetingRoomName.A), null, 予約したい期間, null);
            Assert.True(repository.この会議室は予約可能ですか(予約希望));
        }

        // TODO: Saveメソッドが実装できたら、ここのテストをやります。
        // [Fact]
        // public void 利用したい会議室が_先約があったら_予約不能状態であることが分かる()
        // {
        //     I予約希望Repository repository = new 予約希望Repository();

            
        //     Assert.Equal(repository.この会議室が予約可能かどうか教えて(null, null, null, null), false); 
        // }

        // 確認をする

        // TODO:Saveのテストも書く
        [Fact]
        public void Aという会議室を予約して失敗する()
        {
            // このメソッドの中で
            I予約希望Repository repository = new 予約希望Repository();

            var room = new MeetingRoom(MeetingRoomName.A);

            var ex = Assert.Throws<ArgumentException>(() => {
                var range = new 予約期間(new 予約年月日(2020,2,10), 予約開始_時._18, 予約開始_分._15, new コマ数(4));
                var 予約希望 = new 予約希望(room, null, range, null);
                repository.Save(予約希望);
            });
        }

        [Fact]
        public void Aという会議室を予約する()
        {
            // このメソッドの中で
            I予約希望Repository repository = new 予約希望Repository();

            var room = new MeetingRoom(MeetingRoomName.A);
            var range = new 予約期間(new 予約年月日(2020,2,10), 予約開始_時._18, 予約開始_分._15, new コマ数(3));
            var 予約希望 = new 予約希望(room, null, range, null);
            repository.Save(予約希望);
        }

        // Aという会議室を予約するものは何やねん？？？
        // →　なにをアサーションすることは何だろう？

        // テストとアサーション

        // 確認すべきこと＝アサーション
        // アサーションのないテスト
        // テストケース

        // なんにも確認しないテスト。とは→　とにかくエラーが起きないこと。
        // なにも起きなかった。例外が起きなかったこと。
        // 


        [Fact]
        public void Aという会議室を予約可能か聞いたら_既に予約されていたのでNGだった() {
            
            // Prepare
            I予約希望Repository repository = new 予約希望Repository();
            var room = new MeetingRoom(MeetingRoomName.A);
            var range = new 予約期間(new 予約年月日(2020, 2, 10), 予約開始_時._13, 予約開始_分._00, new コマ数(8));
            var 予約希望 = new 予約希望(room, null, range, null);
            repository.Save(予約希望);

            // Execute
            var 予約したい期間 = new 予約期間(new 予約年月日(2020, 2, 10), 予約開始_時._12, 予約開始_分._00, new コマ数(8));
            var 予約できるかどうか = repository.この会議室は予約可能ですか(予約希望);

            Assert.False(予約できるかどうか);
        }
    }
}
