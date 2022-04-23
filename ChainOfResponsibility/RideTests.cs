using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanCodeCurso
{
    public  class RideTests
    {
        private Ride _ride;

        public RideTests()
        {
            var normalFareCalculator = new NormalFareCalculator();
            var sundayFareCalculator = new SundayFareCalculator(normalFareCalculator);
            var overnightSundayFareCalculator = new OvernightSundayFareCalculator(sundayFareCalculator);
            var overnightFareCalculator = new OvernightFareCalculator(overnightSundayFareCalculator);            
            _ride = new Ride(overnightFareCalculator);
        }

        [Fact(DisplayName = "Deve calcular o valor da corrida em horário normal")]
        //[Trait("Calcula", "")]
        public void Corrida_Normal()
        {
            _ride.AddSegment(10, DateTime.Parse("2021-03-01T10:00:00"));
            var result =_ride.Finish();
            Assert.Equal(21, result);
        }

        [Fact(DisplayName = "Deve calcular o valor da corrida em horário noturno")]
        public void Corrida_Noturna()
        {
            _ride.AddSegment(10, DateTime.Parse("2021-03-01T23:00:00"));
            var result = _ride.Finish();
            Assert.Equal(39, result);
        }

        [Fact(DisplayName = "Deve calcular o valor da corrida em horário no domingo")]
        public void Horario_Domingo()
        {
            _ride.AddSegment(10, DateTime.Parse("2021-03-07T10:00:00"));
            var result = _ride.Finish();
            Assert.Equal(29, result);
        }

        [Fact(DisplayName = "Deve calcular o valor da corrida em horário no domingo noturno")]
        public void Domingo_Noturno()
        {
            _ride.AddSegment(10, DateTime.Parse("2021-03-07T23:00:00"));
            var result = _ride.Finish();
            Assert.Equal(50, result);
        }

        [Fact(DisplayName = "Deve calcular o valor da corrida mínima")]
        public void Corrida_Minima()
        {
            _ride.AddSegment(3, DateTime.Parse("2021-03-01T10:00:00"));
            var result = _ride.Finish();
            Assert.Equal(10, result);
        }

        [Fact(DisplayName = "Deve retornar -1 se a distância for inválida")]
        public void Distancia_Invalida()
        {
            Assert.Throws<ArgumentException>(() => _ride.AddSegment(-3, DateTime.Parse("2021-03-01T10:00:00")));
        }

        //[Fact(DisplayName = "Deve retornar -2 se a data for inválida")]
        //public void Data_Invalida()
        //{
        //    var exception = Assert.Throws<ArgumentException>(() => _ride.AddSegment(10, DateTime.Parse("1000-03-01 10:00:00")));
        //    Assert.Equal("Invalid Date", exception.Message);
        //}

        [Fact(DisplayName = "Deve calcular o valor da corrida em múltiplos horários")]
        public void Test()
        {
            _ride.AddSegment(10, DateTime.Parse("2021-03-01T21:00:00"));
            _ride.AddSegment(10, DateTime.Parse("2021-03-01T22:00:00"));
            var result = _ride.Finish();

            Assert.Equal(60, result);
        }


        //[Theory]
        //[InlineData("0,0,0", 0)]
        //[InlineData("0,1,2", 3)]
        //[InlineData("1,2,3", 6)]
        //public void Add_MultipleNumbers_ReturnsSumOfNumbers(string input, int expected)
        //{
        //    var stringCalculator = new StringCalculator();

        //    var actual = stringCalculator.Add(input);

        //    Assert.Equal(expected, actual);
        //}
    }
}
