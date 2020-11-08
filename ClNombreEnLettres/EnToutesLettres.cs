using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CLNombreEnLettres
{
    public class EnToutesLettres
    {
        public static string EntierEnLettres(long unNombre)
        {
            string[] UNITES =
            {
                "", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "dix", "onze",
                "douze", "treize", "quatorze", "quinze", "seize", "dix-sept", "dix-huit", "dix-neuf"
            };
            string[] DIZAINES = { "", "", "vingt", "trente", "quarante", "cinquante", "soixante", "", "quatre-vingt", "" };
            string[] COEF = { "cent", "mille ", "million", "milliard", "billion", "billiard", "trillion" };
            string resultat = "";
            // variables de travail
            string temp;
            long unite, dizaine, centaine;
            int coef;
            int i;
            bool neg;

            if (unNombre.Equals(0))
                return "zéro";
            // tous les entiers sanu zéro
            // mémorisation du signe :
            neg = (unNombre < 0);
            if (neg)
                unNombre = -unNombre;
            coef = 0;
            do
            {
                // Récupération de l'unité du bloc de trois chiffres en cours
                unite = unNombre % 10;
                unNombre = unNombre / 10;
                // Récupération de la dizaine du bloc de trois chiffres en cours
                dizaine = unNombre % 10;
                unNombre = unNombre / 10;

                // traitement des dizaines
                temp = "";
                // Passage sur la dizaine inférieure pour 10 à 19, 70-79 90-99
                if (dizaine == 1 || dizaine == 7 || dizaine == 9)
                {
                    dizaine -= 1;
                    unite += 10;
                }
                // Texte des dizaines
                if (dizaine > 1)
                {
                    temp = " " + DIZAINES[dizaine];
                    // Ajout de 'et' entre la dizaine et 1 pour vingt à soixante (vingt et un,...)
                    if (dizaine < 8 && (unite == 1 || unite == 11))
                        temp += " et ";
                    else
                    {
                        // Ajout du 's' à quatre vingt si rien ne suit
                        if (resultat == "" && dizaine == 8 && unite == 0)
                            resultat = "s";
                        // Un '-' est nécessaire dans tous les autres cas
                        else if (unite > 0)
                            temp += "-";
                    }
                }
                // Texte de l'unité
                if (unite > 0)
                {
                    temp += UNITES[unite];
                }
                resultat = temp + resultat;
                // Récupération de la centaine du bloc de trois chiffres en cours
                centaine = Convert.ToInt16(unNombre % 10);
                unNombre = unNombre / 10;
                if (centaine > 0)
                {
                    temp = "";
                    if (centaine > 1)
                        temp = " " + UNITES[centaine] + temp;
                    temp += " " + COEF[0];
                    // Traitement du cas particulier du 's' à cent si rien ne suit et plus d'une centaine
                    if (resultat == "" && centaine > 1)
                        resultat = temp + "s";
                    // Cas des dizaines plus grandes que 1
                    else if (dizaine >= 2)
                        resultat = temp + resultat;
                    // Tous les autres cas
                    else
                        resultat = temp + " " + resultat;
                }
                // Traitement du prochain groupe de 3 chiffres
                if (unNombre > 0)
                {
                    coef += 1;
                    i = Convert.ToInt16(unNombre % 1000);
                    if (i > 1 && coef > 1)
                        resultat = "s" + resultat;
                    if (i > 0)
                        resultat = " " + COEF[coef] + resultat;
                    //resultat =  coefs[coef] + " " + resultat;
                    // Traitement du cas particulier 'mille' ( non pas 'un mille' )
                    if (i == 1 && coef == 1)
                        unNombre -= 1;
                }
            } while (unNombre != 0);
            resultat = resultat.Trim();
            // Remplacer dans le résultat les groupes de deux espaces et plus par un seul espace
            // [ ] : classe d'expression réguliére pour signifier espace, {2,} à partire de 2 occurrences et plus
            // donc maRg c'est toute partie d'une chaine ayant au moins deux espaces
            Regex maRg = new Regex(@"[ ]{2,}", RegexOptions.None);
            // replace dans resultat les groupes de deux espaces et plus par un seul espace
            resultat = maRg.Replace(resultat, @" ");
            if (neg)
                resultat = "moins " + resultat;
            return resultat;
        }


        /// <summary>
        /// découpe un mombre positif en une partie entière, une partie décimale, et indique le nombre de décimales
        /// </summary>
        /// <param name="unNombre">double, nombre positif</param>
        /// <param name="unePartieEntiere">out long, partie entière du nombre</param>
        /// <param name="unePartieDecimale">out int, partie décimale du nombre</param>
        /// <param name="unNombreDecimales">out int, nombre de chiffres de la partie déci-male du nombre</param>
        public static void DecouperNombre(double unNombre, out long unePartieEntiere, out int unePartieDecimale, out int unNombreDecimales)
        {
            string[] parties = Math.Round(unNombre, 2).ToString().Split(',');
            unePartieEntiere = Convert.ToInt64(parties[0]);
            unePartieDecimale = Convert.ToInt32(parties[1]);
            unNombreDecimales = parties[1].Length;
        }
        

    }
}
