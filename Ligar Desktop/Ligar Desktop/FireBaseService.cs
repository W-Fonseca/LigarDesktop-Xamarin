using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ligar_Desktop.Services
{
    public class TextoBase
    {
        public string Power { get; set; }
        public int Numero { get; set; }
    }
    public class FireBaseService
    {
        FirebaseClient firebase = new FirebaseClient("COLOQUE O LINK FIREBASE", //<<-- coloque o LINK do FIREBASE aqui
          new FirebaseOptions
          {
              AuthTokenAsyncFactory = () => Task.FromResult("COLOQUE O TOKEN AQUI!") //<<-- COLOQUE O TOKEN AQUI
          });

        public async Task<List<TextoBase>> ObterTexto()
        {
            return (await firebase
               .Child("Desktop")
               .OnceAsync<TextoBase>()).Select(item => new TextoBase
               {
                   Power = item.Object.Power,
                   Numero = item.Object.Numero
               }).ToList();

        }
        public async Task Ligar()
        {
            var toUpdatePerson = (await firebase
              .Child("Desktop")
              .OnceAsync<TextoBase>()).Where(a => a.Object.Numero == 1).FirstOrDefault();

            await firebase
              .Child("Desktop")
              .Child(toUpdatePerson.Key)
              .PutAsync(new TextoBase { Numero = 1, Power = "ligado" });
        }

        public async Task Desligar()
        {
            {
                var toUpdatePerson = (await firebase
                  .Child("Desktop")
                  .OnceAsync<TextoBase>()).Where(a => a.Object.Numero == 1).FirstOrDefault();

                await firebase
                  .Child("Desktop")
                  .Child(toUpdatePerson.Key)
                  .PutAsync(new TextoBase { Numero = 1,  Power = "desligado" });
            }
        }
    }
}

    