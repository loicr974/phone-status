namespace PhoneStatus.Models
{
    public class Status
    {
        public Status(int etat)
        {
            Etat = (Etat)etat;
        }

        private string text;

        public string Texte
        {
            get {
                switch (Etat)
                {
                    case Etat.init:
                        text = "Appareil réceptionné";
                        break;
                    case Etat.diag_ip:
                        text = "Diagnostic en cours";
                        break;
                    case Etat.diag_end:
                        text = "Diagnostic effectué";
                        break;
                    case Etat.att_piece_ip:
                        text = "En attente de pièces";
                        break;
                    case Etat.att_piece_end:
                        text = "Pièces réceptionnées";
                        break;
                    case Etat.rep_ip:
                        text = "Réparation en cours";
                        break;
                    case Etat.rep_end:
                        text = "Réparation effectuée";
                        break;
                    case Etat.final_end:
                        text = "Appareil prêt à restituer";
                        break;
                    default:
                        text = "N/A";
                        break;
                }
                return text;
            }
        }

        public Etat Etat { get; set; }
    }

    public enum Etat
    {
        init,
        diag_ip,
        diag_end,
        att_piece_ip,
        att_piece_end,
        rep_ip,
        rep_end,
        final_end
    }
}