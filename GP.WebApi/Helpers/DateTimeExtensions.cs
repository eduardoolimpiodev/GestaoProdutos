// using System;
// using AutoMapper;
// using GP.WebApi.Models;

// namespace GP.WebApi.Helpers
// {
//     public static class DateTimeExtensions 
//     {
//         public static int PegarValidade(this DateTime dateTime)
//         {
//             var dataAtual = DateTime.UtcNow;
//             int validade = dataAtual.Year - dateTime.Year;
            
//             if(dataAtual < dateTime.AddYears(validade))
//             validade--;

//             return validade;

           

//         }
//     }
// }