using System;

namespace AssemblyCSharp
{
	public class DamageService
	{
		public int validateElementalDamage(string _firstElement, string _secondElement) {

			// Fogo > Vento > Terra > Água
			if (_firstElement == "Fogo" && _secondElement == "Vento") {
				return 2;
			}

			else if (_firstElement == "Vento" && _secondElement == "Terra") {
				return 2;
			}

			else if (_firstElement == "Terra" && _secondElement == "Água") {
				return 2;
			}

			else if (_firstElement == "Água" && _secondElement == "Fogo") {
				return 2;
			} else {
				return 1;
			}
		}
	}
}

