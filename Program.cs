﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LGoH_DeckSuggester
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter exported heroes' string");

            Team team = new Team();
            team.LoadFromCompressedJson(
                "NobwRAlgJmBcCMAaMBjA9gJwKYEkazAEMAmAFgCMUAGATgDYxkA7QgWyzjAE1CBnViC0QACACJYsAB1ZpevYQEEAbliYBzLBkZgMhDBAAuATzh1khAO6EA1qsFq4VcwDNngwyYIBRPQYAW2saSHATizqpQmtq8wSgQWLycAMKYGACukgbahAYGhCjWcDTwABzI2OgqGJ4AzFQArMh+WIQANv5wNSXESGBYKkwGAMrWEK2tibDgAOp6kUxwBulYAL7IkeFMkRgjY62cAAqETBAo2uhpg5q745yiEDFYrcIAshBqflnIrS3bCuRjDxwcAsdjJVIZAyvd6fYQANRw2kivBQ+kyEDQCwIxCoVAApGI2IQNMJnJhhG1nikMOlMsIABKaNAJbQyKAQNyaSbgHJ5ApwYhrMB5DAaLIEam0rJC-poVoqABiGDQrE4dBxWHqNTohG0svluEGaE4YDW4GgAuQ6GweE45CgNSg5CwNWI2lBITA01OtigwgAimkJAtynogbAzEQrLYTupHC43CdjHc9IVkEFPS9iRxkI84iyCPS0qxjtlcvlCggSvAauUsJVNJ46FRSE0Wu0ArAAOx0Vt9AbDUbjbleuaqRbLIUbCLXIf7AhDCCSPyY85oS4GWd7O4PYLPBQYGRab6-TT-QHJqZgD2cLMkt4fKFwiBIhKopcGDFYsA4-GEkskmSGAUuMrzZgyTIssgbIcvEGAjryFYCkKIpire2amsg+qKsqqoEFQ5BdvAREoPAepKHKKg4EaJpmpA+C1qgmC4PgqDOKQzikdQ7psJ6ADSqgiF4Pz6MWwgpKwJZbMaob6JekaWDYdhxrAxAJu4l6jpux7CkYwScAAQm0xwoFgMC5rE8STGAAAq9Z+EwcpoGopxtGWfKVqUxCNDo9ZoFUTZUGUYDNG0HSwHUpCMf0qiDnsI5DK0hBGFEsB9hJUnbHApBTlgmzbDc85gAZrSCOZTEblutyhLuTzCNMLQxtoPyEH8AKlZeIK8XcTxpCSaDOMIBxoBYmjCDgcKviiaKfquBB1H+ohEiSxx+vSBykuSlL1TkY0KOWBRchBypQWAMGcvBwJEAdlaMaFHadChehobAwBaVEyD7R5UQALoyhRBpKiqnDOFAJQlFAUDwPU5GUYaBjGgQmHmvgfbWixnAlFghFdlA9Rkcw3UEAJeTCEDvAGOQI3aLoclNuY0bKQ4sBOEQrgaZ4706RmhnGUwpnlXmVmcAAMlgGhbO5SEIHQXbBRU-mNnA9T1DQbZhZ2xBdvQWEDoVCVJSlWhpcgBnroMRgMpVxvpSqmWpTl6x5TOOxzpwJOEAA5PIABKCRw2u1uFZw-y8AHJ6tWe7Xhl1YIELM2lDSNY0IlN77onNP64gSS0AVgFJbAyG1ASBzwJ2NjInYk0FoOyF0ITdlohe24WCumz1YOKXOYf2cNA3hYDwMQziEDQNBYFQsMGtRCMg1gFAq9WyP0crVrMbaBD1CgpB0PQKA0DxcdgEMKDNM0ugAF6RzTYbyQzSmxszvSEOzSacyLMJfLp+nx3o+iYNESyBYwAKkIOQH4Ut+SqVKH2BWAU4BeXVg9CKdAahq37LFfWV0MqrQdrlfKVUiolTKoHK4rttw1UeM8UQtcNDNVPBgc8HVPCx09B-R8ZMwE-GhBwiaacZpfk4AtHOy186rSLptYC212GwlAeA-OldmTVzOrXWCXIrqISgXdFunYahPVFJ3OAb0ZFfzkRAv6us+64TtLiGg1YsAMEsdPGiSM6IWgjGvG0rFSAlBQM4Eo5Ad6H09DQiWIgACqTAWq8GaOVWm4YFKM0fvGNmiZwxgB8BgDo6Y9KeiMklfmZlAH1mFgQMWEtyqaM8nQeArM4FK1gFqSM91W50BKNFPWc4DbJQdqbc2xgrZkOysgHBWw8FOwIeQ6qYBQmqG9mTJkcRkxryDm7Agodw5gBam1C8LDrxEwyb4PwSdRrAVTk7aaH5BHYmzv+cC4j1qSNLsITJxzFGnXOnBBuHkm4tM1vol6hyMABH+lY4GBAaCEFQWQKgzgp5URcagAJuJ4DkF1G4-AXZPEYwIKQKgPYF5ukJkfBQy5lTsk3CID+4RhAGX0OoD6Ohb70yjA-ewCD1Jv04OXbmuSQ43UZULYBABxWukDKzEDoPUeWfl4ERXqM0nRCC5a9BioMLBV5Eo9Jtvgl2wd46NXHCssh+qZm1X3IeABEcdnMKujeAgLxMB5CpH4PQrBxqTQuenWa35hF3JWoXR5JdpGfytlJY6SjWSqPrhoxuEUkHhT0e3Ax4pjGf20EWKSYALG90BtYzeVAUD2igK1eF8NEZgGXu44K6MN5gC7ERSFzhyAE32SS0qTAsAiHpOIganDNw3zpqYe+MZ2Us05ekkxgQ+UEHySZIpFkSnAPKREcVCD6j4rrA2aoysqBqWbhrAU+N91qrisOK6WqjbDOKv0y2RYhkmzAKMrKaVdVjKmUVBQHasDzJKgkXg7LjXaVNRsg09DI6MOjp1NtbDQ3DVOfCREXqBGZ1-CIvOBc1rFy2qBExEaPnRq+bGn5qkE3-OTYCqdoK83gqIFQQghAuzOC7DmXNCLZ4QpqPAWWNAagwwxUUbFdayBdhqGAnxwT3Y5AAFaEBEP4fOBxlSbhQAjHS8S76stHSpVmL80maSnTkn+o4aQYh0kK6y4gBBqDFeYON8AaDEBlduzw3HWZ-M6D0DpmCukXsNuMsA0532msXMuVcQHCE7iofCf9TxwM2pjjB0WoarPvFrjw2EfDkNXMzn63O9zA3YakbhlLWBrPpfecoz56irxVM6GRx6FHDGvTAIZmZZW0swBzdhLA-dOD1CgCgeokqJNOPYxWqt+BalCdYmQdU9RnA9EkxKHI59BBds4RAaoAYgxGqZUOjxWmmYpL0xzZLj5p3GdmKZq1YALOcDMaxurCBHM+XqTumW7mlURRxOg09GrwCXoC0FgqaywAHiPKQ4DYP7jRZoVAOh1qo67LtQcoYSxVAcL7T7QgggqYWHkFlwLb4UO+tuflgNWGnkho4dd-+wFKtRrrkR2rcbtGHoigC5raaLvIDp2Z7N1GcK0bsSUegC3yBlpnhNgTCBei1tYvjDdhBSBYBKMtsAOOACOQZWgRJONaJgQ16WmTkIOhJI7jvjtSWdsp6ajOen57d+7BBHtrpe6ULdisPtuYaxFBzWKMHqt85q-zOqJl6rBw1B+UPIuUL3IoS1OltnI9tVee1Jn6cZafEh4nlyM7fjQ-6-OwbQJO4Z5BKrhGas8jjW3YUHcu7l57j1vrBAoB7prARXUY3y20UQCjBB+6FdCJqEWmgpB4DlQzwAOQgNYQgwgFPCESiYWSFujvJOt6drl3gjmXcd3-AXi78zWSSNgHIaRsDu9KF2fd73XMqz91xnEusfPxWwXbXB4fieTNNTZXQQwW7C4E1GHc1YQGyFcDAJgZRFPSDFHdPA5TJfwcSC-AwK-fOB8TLT1PPb1a5MAPLURTDCRUvZ4ZA45c-FodA7AfDKvZnGva6EjdnZBJNBvFNIxIFbJJ9NAjAwXXvNvAgmpEeV0cqHraXfvQfBARiEfAgfxOgcgeoF+A+YlEJC+TAUsdfTTRSbTZmXTV+dJJaDANMb+Q-G7czIBSzXQGzEMRg6WLydBB-ddfdDzCKFsYKf7EPQHMPbKN9UHChYqDtcqEA6Hfw2HBPAAKTSARzK1ini1T0Swz0MOsB2jMOzw9X4RyzJ0WiIIeSK2eSSJSKz0ZxrnoMulZyYOfy51TRmVTG0Gb26wBmFwHm1AdHxRKEcTYz71cQHxXgQDRnXlYkIGhmIAUPgB7ySzKVakti8A0Apj4HNy0KSTHT0P005iSIP35W+nMKXWsiGEkC20MHd2ICczqVlQaUij92GO82Dw-yvGfWB2dmCzB0gMwBgNjw-SiwTyOANziPgLT1YU4BmLUFMgLzaBOTGhwEhIyILyEXJxyMK2p1AgKK+grArkryZzUTKNrwqIPRYKqI4PWM+gFS0AaLBQHjvyHnaOcFbTEMRUm3XRm04CoC4zoEW0hg13CWBV8DEH0HGDcApgWJZW0KtxWNt27gd25SP2dwsLuCsAwDhTsxIy8lOJcycOf2ZOuLPQmE-0km-x8IjyeP8IAC0VQARWNgi48zVosTTWAzTfimEEiDlRA5TBosCoQidkQ8Dcs4SMNcjESy5dpgJnS9BBpiiVFSjvlpZmDE18SWseVtBgz5S+DOiBCagHEuxYV4Azhe9xDujJDuNGT8IWS2Tp8DlOTXUskeS9h+Sv4NMhSlidMJ1NJ4yJTf4zDilT9ZSQyb9ugVTvdH9nDvs6gahNSAcn0v9319Tf9I9jTTT4h3jTUwi6obS7Skc-jHSj5EzXTQ0PSSdMjYTsjfSETSCdpE4tzaCMSY1yiozKimtqiWyZkXTkzW980CD0zMzszOjczK1ZdiJCyiBCIKAoAiINdFxgJhJ9AUBhAAB5QaOlQQQU4dTfZYpstY2o1s8HYkjs0pMATNDQ2wqBY49UL3OVYcy4-GPsDw248Ae4n-EHS0v2CWBcsA6LYaB4cLLZBhB06DDPPCo3CHckc5XA0nTgIvINHDZ4Pii8kozEkcFw+vVCZrXC4sUsIXXrV8obLAGgYCkcqXOk38mtAYu0YbRjWgUgDXSA-OOfDhIYS4RCw7YUrfUU3fEBLbVjHmdZLCk-HChQfmeIQYI44gNBEihpYgOxS40gXjN-G489UPbVKc+ij49ZJPZi0I8AtisOGwuA7ivZDPBUNyxQPy2KNI3c-PH1A89DArKnE8-Kmg3y-MQYaS8M2S4jG83EmMu8jg2q1jeq-yrIUkmjZoqAYgJ0eoZ0PSjjH8no9xBzf8hQ4gUyifCy5oYQay2EWymwuspCxylCm3Fy7qjYzyrY7C4BXq2IxU6WY44K3yVU1ScK9qzseASK0czw4+bw19A0vw6ZASnSC0pKq0r4tAdirKriqDXKg5bqwqhqqEN09I7LGE+aH0qqkgiSsmAqs6xqsM6rLEgi26W8tgl6N6A6z6IqgKgapooRYa0a8anM-S6a-AV-JiLxEGdohQpQjXUQNQ3QTa5lbahs3Q1ClMIww6zPY-O7GU0IKwji57YidpEKn3SKv3MKoiaKrU7pK9D66cw06ZYhSWCLf6pc54SI6I9gAKtcnK1HTc1MQoszEqnAz0kSxGw85G8S4raha28vJq7GyMrRfGxS6owk0WgBcm9S2jFouoOWDo2kya+k6Bf82FQgR0eANXDXIyCmQxTQ+stlRsvagw9CkwyU9s7y060mr+GWhtN7M4hW4KeS+gVmKi2Kmiicl9R2LWr6oqOEWLfYfWxc8A6PJqc2sGy2kJa2jGmGnc+2vchGggpGynFGt2wkIwqGvqr26vHG57aM3RWMt6QOse58xo0OgecgMKygLjBUr8umyQ44+O4QqGFOlQ3mdO2s3mhy-mk7fQzSQOjyoO7Yzs9ZUum-Cu+W1zHxJWuu1Wsc2ihKx49uzgTuuQOLHulihPfuvbbKoexAq2peseu26E8qp2yque12-I0e0u1eiM1q32h6xrAm7nGo4Wkm6G-esku0E+lAM+iamXemgUaQoy9veoSfOWLAIlCY2yC-XgDAwZROIYbGeyxJbOgW3OzScgkW5vYu6yN3C6qBYiUTYBhBUB6hu6p-IPNWvzeKzWxK01eB3gRBiqUAtK6LF46A2A0GhAgEvfLJY5R7XB+G-Bme52ohvI7acgzheRchlq68qhlw1g-2jglR5AN3EOgQvdCGEakYzhiQ3osgf8sGKKIKlALsUCuUNIXgEQFIfgU4Had9RlLa1+hR9+1Y87T4VRqU3+nC0QKWmw8u3sPRvowPWuvFCB16oHOimBy0+HRHOxkI6ZQ22lQI+0jB9x4+DHdQWEbHXHJgfHQnSesq-Awgo86q1GvDT2rGten2vGwxmJxvDgtreotSgQ1wHsLjNBDJvMrJnyGQ1AegQbXeZQ0R6iEtH4EQE09kfIYQPiQDfbcMHyHanOnfSde3Auo61EtpkVCAY4Mu+zHeBwqu1zHWQxuxE9TpaikzeYCcIMXw8ZwAmwv63u60uc1jdBtx0RvYg4qEH6+EPB-A0oP8Yh7aVluScJq88AFw+AAAOhKFjOPn2LkhbwPoee1no2cFVlebAHVG1Ani7DOFl0lTmpMozKWofoIEstWtDQ2rkctycsFtdzcpFpRMOlResj3q0YlRxFgVxYFCisMaeozKGZJZGegb-zBx+tSpmfSqBsyoWeZbyvRrIdhtKq9KyMIbEWPNRshpwdOYociYueie3tcuv0Yb6uYcGsppGoUJpovpjp1cD0+aIhIDxjxg12mFrj21qfkZ0IabFK-pnWKj5gFhOssw6xs0qXsy42c37OymuvkoDz9cbrevMdbssbB1CxXBpf6XGfAOsdsaZf+NEbhDaFdXGGOB8eEv3IIeL2IL5aROttS2HfkEzYiexLatzc6pa0DtvbFSSdfIdBxHCHoFVdjqc3-PrAIhoGPsKaNdws0HYGUTbctd2vhebMDJFrnUKUFglva3KxHaVK40D0cLSi6CVocx8gbu1Lio1sXbGYNupdDaKlmdQZBogwtswcd10BQL7WXxkcXwTcdv8eTcvaCbL0DJtswHvfRJkuFdxvq0ubzYfLuf4NfPoC7EnzA-GOjq4avvQU+fnmcBqHIG6El0g4PFPmOA0GeE5PiG7qhcWPqe3w-vfkRe-vtdsEdbuGwC6bryHjw49dUhKD7FFcn3cOJbnagYsao9NWNo0FNq-lpeQbqkYrQdcd3YzyGAsEwD9D7UZEIAGDhtPenv2ZdsE+eDw2c7RKrkvJZyfaiaHLzba1K5JPudfPyHaOlWIFY3U8yfcTqH-JqC7HIAIlIBQHV0g-pCXEkDlCMDyBEEDGDBgsGgUBLDUJ5oO3bZFOtc4ICAwvq4Hc4HpExGYmw8uvgD-Juond883v0YLJMcgeboeKDf8Iyo4ti4cZQcNUY4Sx4oOTslPkclaGclcmeD-TkHsEQy5e9L-B9i8CSH9IgPsl+-+5QDBIfck-w6ufYONbh6chckR-2Ea9o3aK4ynxKBhlpqre4f93-JoEWyoHgGbWG73bkl0HsphbfvjSUYc95yRZ-p28luJGlvszaXvx86esHI5xOJI+C7I5AEpf+pDaQZe7qhXY4p3Y3NMKz1hp2cTc4B5f45PJOfE+ask5lolalebzx4HkG01FBilQA9l1dH-KnyGzdfMsg4-nGEMD8BEGoiUAeAgDCaUzQBUzUwteQrhfs8BP3y268vFp2J6iw6ONoF6Hw61nQQC9xFnal-nYo5l9NTdNo8+Lqm+NOCjeS6+80F0HBOAh47Pb44vZPKkuR8q6k851feUqzXN7VHrGKCwFKFt-J5HP-NVjyiIhVg1z4hfgvks5EFAXGFUEKrM5D9hcUcQ85nia5+2-Ubj86wT+KF6ZT4ivT+u+Gfeso-u5mZo-l7Dei11vKhV8+6Piy4GFaEtnjc1944K8AjTa4QUQN+9soduilZu4O+NyIKqgi0p99JCNQfoszQIATxUEzJWpBrheD2RF8LwK-ESF4DjE4OofZfuHxtYFt1+0fF3NKzZYJ8SgfZOVPv29ZoIJe7+OdgG0fRmwNwd6a2IGxnLTIt2VnZ7lf1e4x5B60bNHDK0MCJ4jwoPXxvgTEpFcV8QgqEI3wYLyUpWArQ4sAPrQ9haehaSeKTw069E+MwHOgCgBQA9BaAGuJIE8ASCfgwS4gCiLoE27Wcs6HbOzo01CD50nORAjDh+0O6EV8UkYZPg2kuJdAgudAzPgwL7BMCLYUjO7uwLo60JzS67A2uASV7vd4i9-T0FJQ1654HaNfIvBThLyo0G+v-M5v-2Qit8+KcrFhgQDATeRyAaZERh1zeZddIwnzGgFQCdDkBigfzDPAcC5BYASmi-Vns5XSRr9XBx1TfoWH27YBPBEqKgFKj35dgfIorXroHlI4jhQup-KIZwEi4xEzaUzDdtFhCZdClgHINfJxSY6LNRGSQV1KwH2KYh5kr-MHkmwvZ+kTyITermJ3K4Scm+G9P2tcxaxr9tuX7WjCWgnh4xeuEAnQTWz4b1ohiBTbyOfUSKHs5MigAYC5HUDz9bG2Apfp2xcrdtjMG-GPn-Uw7b8XWAoBoD4J85ax5h32GsH4KP4kswhAye9NpDYHa0ioTjN4pfzo7pVjgxffgaXyPiQFeSzwDjitUZG5dMh+XWerkOAg8paUt6CIZdA+EMEN6snZDn0mYHyji2FNbED2B7C6d2uB9b8rHUI5M0cUYAfTlAIIhDcNclcFAGkB+CwcX6q3K1uzwj6eM7Wbg2PmMMcgTCE+pASurdS1gXcpCqCDPisNu6jMz+dHC-jsPiGsUI2yvJLqr2SCXDrhTAW4RPXuEVVHhqbBei8OJJvDI0io9emzm+Ho83ofwrCgCPJKEAxq6oDvGCK65adIRdbEagNhJ6iNm2ZLTOnzVs4DDP6Lgntqh37ajDCRw7G-F5l6Z4p-O32HENfVpH0CT+OfZdkuFXb5948dUTgSXyTEEB92rQQ9gUhPbii-GH-FNocwXoFEPBBYgjFmyq45saur7HevnQ8GajD6nAH9rCi0pR0DRl9XooMxNF1pnQDiKASgFLJHwfYaAAEEbj262Y7BPYhwX2NX6R9CBIw-EThU0bN8cQ0MPfrvH8EbpQxOpe2BGPWHJVIcHIgvoD3ma8jtxo49LOkMzE3IAmUo-IkOwqwFCbxGEqVs+JUGywi0DmUyA2NRjy5IRQVEXrUg6EHJRukQUYCIGgonAxA5g5UFem7F1N4J63YmshJRY89cK4whdM3wcwlBvOAYmYdQOybzjghi4z6paQ2QYBDOMYulgnjl4nCPu4NI+PBjGiZdxhYoqeseMlECcYekNPbt6LMhCtPhJYmTg+PzasZApB3F8QIWO7UBeuPfASdlGHyQiQJA2EYm11TpJQCgzoOYMz3g5h8nBkUlpkXVQnAJShxI7sDQH9FncRs-g0ycsKujXYyWsAJYBS0sn-VNxZE9cRRJIRUSUhmxFFnM3-Qg83+WQ8gQSEh7Q8Ty9XEKQwWT4m9W+23FQQZMip0A6A99SthWgGwd5SgidWOlFGA41Sd4WrcYhngMhpADAp8TQCIBNZJAr8NjOJI6MKm4DipD5YYZpJHGUFL8BAmWjQDmHYSgxNYK7k1PI6RCWRnABLmu1WQK8jaURKLudScnJCXJnoE+MVT7QlQ0A6WavhKMYl+S9ewnH6dQR-7vDDeoUnEi+1ob3lVR3BKgrwSrGcAiIxxfFBxGSlpRoBporSgIx4nnSDkl066efDukrUHp8EXSRiP6HrcPpPbPEcQOJm8EqpAeWqZQJDHUDQZkvdWhDNgYEBoZa4gGnVE2HRctxg0hcKZEaqYy-uOM8aXjP45PDUaMo+WTQTkHFjKZ946mRwQfKOyOAjMggMzJxDKdz6dQqapIT9HHSeZZ01OldJukYBhZ+cUWU9L6G9ipZtMz6Q6y0leyb8AM5WaFVVkLD1ZQQzWURMhk6zxYe2bgZyOiyGykZd-VGZwHRnmy4Klsv0LjJ8n4y7ZC9B2TwSdlsTH2zfIMWj0Jrik6Zv072SoL9mszA534sniHMaGQifEytaoTUA1y+VL8IgDpnzyNw2ReI6mF6TgKxHpJ1JqclzlpPXnWFM5gM07irOBksl8JdxcMcyO1kzIYhes2ZhM0ZaJiTZMyTplTGgJeTdm4PW2TmOeSQ1T5mIeaS7OfZuzYmLWdSaAoWA+ywAAjJzOxEQFaDOuqMCETALNHtI8UlAenrxU0C2j7Ric1SS6I8ZcEj5gqDDtFJ9GKz6AjEZPsRWoG0Bb5TdXUpOTC6Ri3OGzF+eG2BrGza5EoFMV+HTG8JrZrcwBWeOeR5itiV4ugr3K+HhT3ZvwpCf8LHk1jyAdYzQdtPQXZRDKWC2FM4DA4KFWMiRMrJiH-TCBhU7nWTAVL3mOCu2A43ER6IJHPjFZYVd1rdWIjTiOcBk1VBrOaljgsQ7U1YJ1MXLPyep+s-cDlKHQDTBFYAUVH6A5biLuWk0+es8kSXgK5KVIpacooSVioVBA2RHlmUbZoLsQzgZsA4nqAcBZcitf8bNh3iwilskHJIKtk0DrZp+uObbDN1ba7zMRDilym1m-pqNypGjb-jfhVhJ9heYVJWtKiWEBLwZRcx+Y5PLnkSxAES5GeuU-no53OWOQaDjjxwjRtm9E2vjkIJlHNQ0+vMmX-2zbScqZ0CnnM0z5ytNYpincGOLmbTsy8J9SzgDpz04Gdl5GAEzgynM76B0RfSyWWQtayOcZZLi9pu50zlAdL5oVeoP0ypFOZaBMVTPqsKXH+Eq52w1Zb1OEC6y4lw9OuWlwwAZdQyLQHLi3L2a+T25zyErsSSyVFC2e9yn4Y8q-hqKFOtGZrlKm6D6i4Yho2XPjH-LzyAZi85eSwHQJrzOmEBbeSQrW5QrD5sKlCcQLgWIrx2lA1FZcQxWsLxy7CluripmYbLCVUS9ZdEQEVkree1hH+UbjpUALsxUi7aCAvlXOzzmdyqBZypKnIBNVCCpBSUBQXaKg5sdYbOKu6CSrdKRnGVWkDlUbyFV7AHeSt1en7zNIqq5xeqvcGdNM5J3ZPgqj1VywDVOKsJTDjNVxD7JdUN+dapY7cK7VrxP+Vr3PZnLGVrqgqnAtZW3L2V3qssb6q-kbzXltGQNcGq+W8MsFu8IbFq3CAmCzBFMdFs8FsruocAzwOyMYQllJyVVtrKPlms9E0TJhCCZoYZLqnGNRWJxA1SELVHhDGRWs8ZuWthk8DFeK4hMacIEEP8VKRuOieINQy+T6+76ztbeOKF5LShKgrAMpylRMYaSU87Qe4gEbAcnQx3NFEvKM7tBNAx7LMJOWUks9bO+6Ffg9i3Vc8RlGqnNYrOxa9Mh4QYsgKQHmUFzgQJqz9ClUiWzNEhNapZp7Q14nKdedfe2a03-V6Tcl0C7nioKzL6ThsLvHRfUPwDGNPm2oIbFAF7CtoM80wdzrKLUDyA06gIXgGupfpYaHBOGvARt1Kn04T5xGvSTvDJFeKgqStUgEdLMncg6NIcBjXZLi4Lqn1SQrZfErY2hoUlmcTjWcsJmpEPVbK8VpK1b5m9eVA8LMvjBdDcQylwc3ogWp+W4pigpkGpKYq+4ijfg9o+9qJzKz4V11pC3Db-CZEYU7wrGOWRCEyA35rN5ms7j4l6AuFmw1GrFYXIfmWki+n5c1bM3a0sbzhFW8ehwiEpHiJBP61GpKEhC8bnsClH4eORpCQgyhJbAgPoLwWgbINwqn8TBswWmiRMYmQJPgoOTj8DAsmeTCtQD5B9bs+W5VYVuhWc9hlLykcW4tM02b8OQ8L7GLzxSYrTGiy1rf9WY2MbN2XdHrRnjwweDDx3k+lW3KAU05YQIOwLV2v7m1dEWz4gNYNmGy9h6eoa0VfotNE1I6AeMSgLZJS6uongSUJfCtQVAtAMAWWuxf0oQmSlitBGu7aMq7JJkSN2oMjT0CVpoJKKCythYRJoZLt-Cv2pzXDIgKAFg+pK2taECo5pFvN34XzUQRPJhAXYE2+zPxum1K7JyKgyKuxAzK47VWo8BVKQAWpuhRVTYrBQqk1CoInqGuLwFcKMAX4jcogaTLlqVXOirtQwntqVq0mJKqtpk-DlRp8XIJmwRLGjV9s4XESAi-U4XQ+otSkTNlzHJZh2s-V5c-G2QhXajQ7Ww6ANqkTiTmpA1yx6MTGMTRjvJ7NhgOjGcgUbu0UZ5OSCmYCGtQMAlgCBtTHTVbj03vSU5PbDXVlBHHCp0W2w57BmQYXkioBYDaYawvs0Go+B0eiuYDX4US6lmfejFiIMEoca0lV7Z4Evsxo9zJOorNXejwSX97pQ4WoRPaBxAMZbJJeyQjUkH4lAVcYucgHCIOR3gSwViuUGVmp2s929YpDNSEio7e6j97uDMkLwDGj7DGYVZkhPtLX+EGOvCuMfPvj1nCM8W+9lknk5Zfq5d6+qQSgd4176QteSlA-Nq1FgBieI5ZTsfXZlMKmhQxEcoYJEYZ4v0rUdkMt2hapqBlCLG7Wqq+lM7Xc4yxWaJhq2UD7e3rbjCHua0ES9SLfNulZPIBhwbJcBiIgjK2Ffwa5Nq3tgUgFgjTgeqI2XaJTSXTSYeQ44KVnuRUfZiA++wFEYZgAqDqhWlEtNUtVZSo2uoMZVrHVVmfNqAeULjCgA6IZ5oKAGfQA6IOyt63d+mnEZ6FlkYdnWeku-J4rqlcZLi0MD7TdyNWpRWCAu6ZI9xhn2MY9lqyZqocl3g442XmtffjNmlkMTDxvfAwJr3oqC902sGFLUKg1qgqNIxHeNYdL2cy60+8XxERGpImC9APvNQPJPc5QBI2ykp0Qh301DLPdGEe7QisVlQDh9t1azWio5wKpIwYM6XtAemRC7Ot4BRyQUaWalaZdGQsHd+rKOo0TjlRuvFKy90qCxMFSjMr4koMfNIRbSXxK4GGyArT4kQGQEbhFhpA4g4QKzi3rYO07nBDDLnlYfTl9b3cThvfid1FZBRNjPO0luODamTgdjRUFcvOT+3RY8+C+3rbNrpDsaMD2vNJX5tG19aVdSpCw0pTG2VaVBIxLjBPlICiFmjsA9k4XpxBuHZ5WCiVX12jWiMV5sqnkgmq3lJrXdUx4qb-qGlpz5jA6xWcHsROB7wotSNpMWvvnh7i5T8q1fiYTzVqiTiRb+Q2sdUPCW1kO0CG6oTU3HXZHOAeXQ1gU5qA1RuoNZPhDWcm4t7iWWP+WU6EB2k0qdsQwaMLNBC4y+HAJJCdRuQJj4JtSfhtu1lSiNSpvSZKhANncNTRHFsFAekP-UsjChqtdGKOOiN02aBwbeccLzNgCQG+tGt3OuWFCrw8lMVnQEAG2sVBeMLMj2G8iUGsddaPrmDBAnaxQKFZZoIIBSJ5SBSmGtg8-H03SyrsjO5M2fPcVl7TDrmcfeAdqT10edk+8HI5v2PRYhdxZxTTxrJMp7UllxjuTxrtN2F6TTeF5TYbxStQd4Qq5xNPN6I4TEtarBVIti1D0H+ZTciwCD2XxKbO4N056SmvsUQn6GxhRM0ZsVNLnUzqsMjQ0CVq0A-s257E4cHjHZHpms+wszwuNNOlR6ZZs4--MLy3IazBREwwoNb7rFVpHEagOxHR1enY6vrT83jCGyq4gqGuEWOl3FNEKsB2muM1CvCM9RJkWk9Cc9jxQ4svFbO71rvG52h6ZgQS8lqEtzOmpYDBpuqAAVxzi7EDr6ketgzLOlHqzUgqizvqb54HOJtRITYxkYzbxJ5a2yapxCigDZmSrFoSVgrZLsmW0wZg5LxdGCf6N1V20S22Tgs8G9144lC6uYQR7pULQUc9e9XSPhcwcN-As2XDe6A6JJOkpJcZfJMEBONNZmhcYYsvyCcl1R6bcVY6MplXyihUGCMUICemnLFaXsF0ECQTxWLqUrBWyccwsY0tR8cglTEuBJKAGU5+xTOeKke7jM3eqhbusINVTmwFA0Kof3ko+Imtn27Y+pajyZWtLzwfM4RaPg4HklJl9JdtBwPUXyrUrQgyoPv1cY5Nl+li7Ll0afmRqI5VwPxMg77soJTwADHGDGs071uMxzNdweIGSWsWH557fixcKEtEr5jZK1woID4qYuFa5zUnAQNHmnSLEv0KeaG0+bKT6e88VjdpM3mKrB+riSftxQ4hUEY+dsUHLv1376wLzJ610dYhQAR4wFARgpuf18A2AlwDbAUThBA1wLrByC+t1CuYUd1BIpQZiyVI7wlrPuKG99gBmBDxDYe+GxHu6kz61lml-S3yLRkyCV9ZyE6zWelu4HLrrfaW0QdfGwDaAiPMXE0eatvi-RNUl+GRCetvGsFLGWgHlELQa44QdoxHkwDKZoBJAwQYCFjJglgnRbUKqa2rzFoaqsbN+aGFMtuoAzLixQFWxtZvTqjr1xsRiKF3Vu6nutu14QEjayuHXccXseQAqCSjsBxoUJfKz+G8iSLTroEEJuXjkUVclRdeMVt5CVq936gebNfvJxqtDrmhQFWnqqxOmyxk6DAJ6-ydNET478FFMTbPk-hzFWgx8-65CpCtOK470pXdZqsVkNB5bngMXJcTmH+KlLO5lZSjZF2HmP5Hmk8yUcbvy6MM-mooqVYgXaNbzhdIzSoOpIbSQJNY9mTSM+byEIHOoP80fDeCdpdAx2uOSuBsYsHLwIRmU2KVjvymt7EVh7TLUJ5kaewfucGFuevuYXQgd6nI3hZc1hY3NCe0RmkJftnm8bF555PkPrPsSqjUrYDRTcHgtAQJ-iYvV6YzLkBH9diGpeTyLXsWhCnF0CZ6C4Dpcme294K9MZhXzmkz2alM89jHiCGGkfnS4htJIeq3NrGRoqPta1tEr15CFA67Bg4THXX7WBmHnhgusc5gtUrKjDw765Qop8BERw34kau1JCmT1s3aaNdtOYQJXNo+DNwMAXxQTQl6O+7qQmwX47GjhC1o69b4c5a8l4xlsZ3NmP9zhpos4-bUMvC8rTDzA7yykEhNnHyCVx63xUZjzYU+KbWC+fGxvi-HBkktLHXIHx0e+TGF+P1ZCTKgYkCDlfGplYAmcbGyakWwDahVzmIjcK4BLg-sw1hs5PuMVYYzUE5mTHdwCh7hbWUP2X1et3bn+pxsVmKTLD7aGw8LHkzu7dJ0m4Cm4ej2LeRaRjH11ptCPTI7EF+HPfJ7Vh-yzGIiL2Hxhj9MAggfwLHNeByhNwKDzwGg6Kk-6EzsxyZsQJ91VTmhp9zoCtaHLaxYbGtQu4-LSsl3rJtkjG5uXlWnOyL5z3XhnvdVf3PVCAX+7atXANPdOcw0tLFq6Cjxju-7WXN0HFVNPj6dQVOjzaDsQEVq4gCmIpJqYv0+wMzq7XKbCvJPd10R57NKh0cfZvl0NmkVsfRPBKsTW1mAztfMcWrCXut6iTgw5bmnteVZ1u-uAqN0uroe+ls8tIAYqDVW1AKkmZG1a-Ox1po6oYNz3Q1SNcfsCAPGusLOpsHtTWVzvf00Kv1D86dDrupXR61m+AqxE6nypG0BUTSlrPqlH3T0iWBD6fdKF3rzbOCAgYPQK0HmSnb6w5VSJaBhUDl3PQkNNyVX10MFWbXlpl1daYKrXmf7iqFx82dbPX5mTQUY7lKneeO2CrDQEcmPCXm8uWbolNFMI366r3-LgfCsvZWjfKOO99O7+jNdc4Sgu5T2OvJk-w4T5EjbFnVy1IxMhKb7MSoEPidaAJ5TXpLwZ3PzuGv3O3BN-Ispr7eeQh3tFhFW69i2oINpOoFoV049umj7ELQLsOy5LNDPZBFO5+sEeEu72oT39GEyOMtsLWWFMV1SJAe9Y09FLRj3N3nZ3OWOcLuww0xsrfd1yZBaQMEjssxyZYTlxxeoNS4Xqm3-3AoAe4oJkFW2BCLQXsM4GmGrbXzFaBtCrmoBBRTQP0IAA");

            DeckGenerator deckGenerator = new DeckGenerator(team.Heroes);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            List<DeckGenerator.BestDeck> bestDecks = deckGenerator.Generate();

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";

            for (int i = 0; i < bestDecks.Count; i++)
            {
                Console.WriteLine(HeroStat.Affinity.Names[i] + "(" + bestDecks[i].Power + ")");
                Console.WriteLine(bestDecks[i].Deck);
            }

            Console.WriteLine("All calulation done in: " + elapsedTime);
        }
    }
}