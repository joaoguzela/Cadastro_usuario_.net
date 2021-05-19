using System;
using System.Collections.Generic;
using System.Text;

namespace UsuarioMrvTeste.Infra.Converter
{
   public interface ITwoWayConverter<TType, TOtherType>
    {
        TOtherType Convert(TType source);

        TType Convert(TOtherType source);
    }
}
