using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bajiquan.Database
{
    public partial class DB
    {
        public int? GetOrCreateLuogoDiNascita(LuogoDiNascita luogo)
        {
            if (luogo == null || luogo.Paese == null || luogo.Provincia == null ) return null;

            LuogoDiNascita l = LuoghiDiNascita.FirstOrDefault(a=>a.Paese.Equals(luogo.Paese, StringComparison.InvariantCultureIgnoreCase) &&
                                                              a.Provincia.Equals(luogo.Provincia, StringComparison.InvariantCultureIgnoreCase));
            if (l != null) return l.Id;
            else
            {
                LuoghiDiNascita.Add(luogo);
                SaveChanges();
                return luogo.Id;
            }
        }

        public int? GetOrCreateResidenza(Indirizzo residenza)
        {
            if (residenza == null || residenza.Paese == null || residenza.Provincia == null) return null;

            Indirizzo i = Residenze.FirstOrDefault( a => a.Paese.Equals(residenza.Paese, StringComparison.InvariantCultureIgnoreCase) &&
                                                    a.Provincia.Equals(residenza.Provincia, StringComparison.InvariantCultureIgnoreCase) &&
                                                    a.Cap.Equals(residenza.Cap, StringComparison.InvariantCultureIgnoreCase) &&
                                                    a.Civico.Equals(residenza.Civico, StringComparison.InvariantCultureIgnoreCase) &&
                                                    a.Via.Equals(residenza.Via, StringComparison.InvariantCultureIgnoreCase));
            if (i != null) return i.Id;
            else
            {
                Residenze.Add(residenza);
                SaveChanges();
                return residenza.Id;
            }
        }
    }
}
