using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Domain {
    public class 予約期間 {
        private const int コマあたりの分数 = 15;

        private readonly 予約年月日 ReservationDate; // e.g. 2020年1月2日
        private readonly 予約開始_時 予約開始_時; // e.g. 13(時)
        private readonly 予約開始_分 予約開始_分; // e.g. 15(分)
        private readonly コマ数 koma; // e.g. 12コマ

        public 予約期間(予約年月日 ReservationDate, 予約開始_時 予約開始_時, 予約開始_分 予約開始_分, コマ数 予約コマ数)
        {
            //todo: ビジネスルール：10:00-19:00までしか予約が出来ない
            // 予約開始時刻とコマ数を見て、10:00-19:00までしか予約できないことを確認する

            var 残コマ数 = this.残コマ数を教えて(予約開始_時, 予約開始_分);

            if (! 残コマ数.に引数が収まっているか教えて(予約コマ数) )
                throw new ArgumentException($"{残コマ数}を超えることはできません");

            //todo:
            // 1. このメソッドの中で、予約開始時刻のDateTimeとコマ数のDateTimeを貰って、
            // 計算をして、10:00-19:00以内だよね？ということを確認する
            // ↑DateTimeをおもらしするのは止めたほうが良さそう。
            //
            //   1-1: Range が終了時刻を判断する (from 予約開始時刻、コマ数)

            // 予約開始_時と予約開始_分を渡して、残コマ数が取れる。それを比較する。

            // 2. ↑の計算を予約開始時刻クラスか、コマ数クラスの中に委譲する？
            //   2-1: 予約開始時刻が最大コマ数とかをくれる？

            // 3. ↑もしかしたら、それ専用のクラスを作るか？

            // 最終手段. コマ数をやめて、予約終了時刻を作るか？

            this.ReservationDate = ReservationDate;
            this.予約開始_時 = 予約開始_時;
            this.予約開始_分 = 予約開始_分;
            this.koma = 予約コマ数;
        }

        //todo: ビジネスルール：30日以内までしか予約できない

        // TODO:開始時刻とコマ数の組み合わせで、ちゃんと10:00-19:00の範囲で収まるかどうかを調べたい
        // TODO:開始時刻とコマ数の組み合わせで、終了時刻って実際何時なのか？
        // ↑これいつ必要？

        private コマ数 残コマ数を教えて(予約開始_時 ji, 予約開始_分 fun)
        {
            // 開始時刻から、最大何コマ取れるかっていう情報が必要？
            // 1. 開始時刻から19:00までの取れる最大コマ数を求めて、いまのコマ数を超えてないか
            // 2. 10:00-19:00まで36コマまで取れます。いまの開始時刻が第nコマ目

            // 18:00が開始時刻だったら、19:00 1h * 4 = 4コマ
            
            // TODO:日付と秒は適当
            // 日付は関係ない！
            DateTime time = new DateTime(2020, 2, 9, (int)ji, (int)fun, 0);
            DateTime endTime = new DateTime(2020, 2, 9, 19, 0, 0);

            int miniute = (int)(endTime - time).TotalMinutes;
            
            return new コマ数(miniute / コマあたりの分数);
        }
    }
}
