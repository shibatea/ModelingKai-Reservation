using System;
using Microsoft.Extensions.Logging;
using Reservation.Domain.Reservations;
using Reservation.Domain.Reservations.MeetingRooms;
using Reservation.Domain.Reservations.Period;
using Reservation.Usecase;

namespace Cli.Controllers
{
    public class 予約一覧を表示する : ControllerBase
    {
        private readonly I予約希望Repository _repository;

        public 予約一覧を表示する(I予約希望Repository repository, ILogger<予約一覧を表示する> logger) : base(logger)
        {
            _repository = repository;
        }

        /// <summary>
        /// メイン処理
        /// </summary>
        protected override void Main(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}