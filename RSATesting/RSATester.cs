using OpenSSL.Core;
using OpenSSL.Crypto;
using System;
using System.Security;
using System.Text;

namespace RSATesting
{
  public class RsaTester
  {
	public void Setup()
	{
	  //FIPS.Enabled = true;
	  Threading.Initialize();
	}

	public void TesRSAPadding()
	{
	  var pass = "f90fd9da-8994-4bb8-89da-378bdffa3fe0-4722455b-4955-40db-b72d-276c5333ecd5";
	  var s = new SecureString();

	  foreach (var c in pass)
	  {
		s.AppendChar(c);
	  }

	  var pem =
		  "-----BEGIN ENCRYPTED PRIVATE KEY-----" + "\r\n" +
		  "MIIFHzBJBgkqhkiG9w0BBQ0wPDAbBgkqhkiG9w0BBQwwDgQI8ymdpZmnNYYCAggA" + "\r\n" +
		  "MB0GCWCGSAFlAwQBKgQQKw7kpmLgqHBrq130CYo5LgSCBNBjYqyTPp9Qn2v+ynuJ" + "\r\n" +
		  "BVcCJISNt2zQ3yV+cvNXpjGwbURxZmCO4OJXIqLqY0Vz0pFgj5I7kikDHSpP+089" + "\r\n" +
		  "Pg8m5Sw96jVaAQiuRFv3L9ldeGbJZIjZTCofbVUyk57qpYCspjefqlqM/3QAMcFY" + "\r\n" +
		  "dUfHTur1FGG6+DsY3/bXWvWh040r2Iv6JJr1SOeTPISEUUghIulV7N8IiiE/B4I5" + "\r\n" +
		  "JIX7EyD99PM2ZEHNh5+dtcIagRpyB5RnMMpX6QiIJ/tPnSy7l4NoVeed9/TztHGM" + "\r\n" +
		  "jVEytN7E/dDtoQ0hIyxSQgLyj0WRZhXjhXICZ8XVE9CitAIo6nLLU3VrpPpcUXIx" + "\r\n" +
		  "mFRFS+YgpfitmlD0HI3G0dd2pd99tU7reEjPTGCiJvfAvBw7VRpGyZb1BBUsJ9Uo" + "\r\n" +
		  "g9oEtNoc3Ftkx551ID6GCKEXLsmheQyD1asQ2qZlgt/J7sO1FPc8IMrAy4UzgqOx" + "\r\n" +
		  "ODhQRoRmmeYwbv7B4s0szpg9Ov8u7cut4a6FQPL5LnlYA2aUHVpfc/MnU67R0DFh" + "\r\n" +
		  "9IW+EoT3OdW6nwfDsSEpcunaYozMesiKYLWMAlVTlsIoH0Zy03KxPS+CuwoyI3jT" + "\r\n" +
		  "JAO7nAqYJ3F1LjdBDkAXtTTkrMHK37Kj0II4FQGKz9GF/3xiyKzw2dd3SFNhDx0E" + "\r\n" +
		  "Ktm8p1VUfaKA7m7aZfd4f2/lVolfXVNgsg0mF8fp3GfD1ScObbCNYnIHaR7EAbkt" + "\r\n" +
		  "jl1bq9jDg7go93IrC6nHRFaQVrvM92KGL5I8KK9HbT/qS9VsvnaS0UxMMz7aniOM" + "\r\n" +
		  "3AbgEWpCk4iRxcCoifnseaowrRnIuJ4lnOEil2WjDAKozT6+QWM4GaXaH8Lysjzb" + "\r\n" +
		  "D8xLwAriLmaklAnyALKbhAVS5/SISmkbYns8X2CZGEJdu0xsqyDJcsMlWJhbwzHb" + "\r\n" +
		  "YsXQc9pWv7eyuWFzbAxvLag5veToKrrC0H5liKVx8mBw+iAyeW2iRVum6rDcPuo5" + "\r\n" +
		  "W/Ce52pzqCIeJBcrQpukSfpyR7+f9He2jwtLUhOspcTVzMH4KUUsUrerrvOSH9s7" + "\r\n" +
		  "4n29C/SiLZDuO4FcbovCpvNS5r+p1cONWS0xEyVdX0M9Rzp5CC1I/mQihpHYAZz3" + "\r\n" +
		  "SwWId1vG+3obL0GDLQ+oad/Vwr2WPR2xSyIY069JRN4QDpVxNK5DAUcPZOyeuD7P" + "\r\n" +
		  "PdN+/pab9tluiL0ZwAgt71ohV/0yjEm78WoBBi6sGf3ynYidoXcJjU8yloax/Gac" + "\r\n" +
		  "izN+JeuPh7IePMOAWV8xqhRMBpooGeb315hO1YnaHrtipyxnbYuJfz2Qy82FXvhx" + "\r\n" +
		  "KXF3iYZ0Szyn1k50OGFkWkmwUjc2X4NsJXRFi9fi6mufBeAK4oXbEpxKcU2U02Eg" + "\r\n" +
		  "HzmQEqi16/5Zbver2SP5e8lOsDAzVg1Z/C8hS5BgiJYoNG7VHoBk7xTgDf7Pjuu/" + "\r\n" +
		  "TT4OYyaKIwXUP9QzcBeLCGvO1kG+tFlRfDOxmP8PCL+vb7LzammbWhnIw5y5+47M" + "\r\n" +
		  "HQR4Nbce8q4CdsKtYzr5vGa072eTi11ugyo/ihVygv2nEtOvy6FGIlj6/mzDkgTm" + "\r\n" +
		  "POUW9MIyr1gPiKmkvH3bEqM8dFikPmKrvg98Xt0WK4i+IBiqd5l2WPVcuUixVKe6" + "\r\n" +
		  "i2hq8L31ZJJ3fkl4aq/TQ2kPWw==" + "\r\n" +
		  "-----END ENCRYPTED PRIVATE KEY-----" + "\r\n";


	  var messages = "THIS IS JUST A TEST";
	  var messageb = Encoding.ASCII.GetBytes(messages);

	  using (var bio = BIO.MemoryBuffer())
	  {

		bio.Write(pem);

		using (var rsa = RSA.FromPrivateKey(bio, s))
		{

		  Console.WriteLine("rsa");

		  var key = rsa.CryptoKey();

		  //	  var ctx = new MessageDigestContext(MessageDigest.SHA256);

		  //var result = ctx.DigestSign(messageb, key);
		  //var result64 = Convert.ToBase64String(result);
		  //var digestb = ctx.DigestFinal();
		  //var digest64 = Convert.ToBase64String(digestb);
		  //var digBytes = BitConverter.ToString(digestb).Replace("-", "");

		  //  if ("58cd62d40406cea83240447720c8d60a194f8293ce81f39c983a285d2497eef9".ToUpper() != digBytes.ToUpper())
		  {
			//	throw new Exception("DIG Bytes check Fail");
		  }

		  //	  if ( "E9jp8tFcCiTQw21e8tTqKcE+Is7hWXK4/k7fyEbcoQxLc3+r3kBjlvnjGGkEtTj9hiIHiG/HF14WFNU6e8fMSBiZQiXpoOCG2n+ScSlcT56k+6Ofk+VMXVEgKdM9pL89UEGSC48701uf5wr8+srOb1vIvl2ymvhBxrSh75icL+eT6bUVlrlOpU2Foowo1otPgQnKsi2ekUS32biXDoIsX10AqLubIT5nJIfgMQ81Prcp890ZL20P7QJu83tJ9TDdrfGiuEveBJmF8+jJCsPBPwrytwr83BvMAhxk7g5kA4LTYqtFentq4IKo8rRMTJRKw5S95OOFN7i7LH3nP68Hzw==" != result64)
		  {
			//	throw new Exception("SIGN Bytes check Fail");

		  }
		}
	  }

	}
  }
}
