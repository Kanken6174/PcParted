namespace logicPC
{
    abstract class ACreateur
    {
        public abstract ICarte CreerCarte(string input, int lineNum);
        public ICarte unTruc()
        {
            ICarte produit = CreerCarte("un nom de modèle   de test   séparé  par des tabs", 0);

            return produit;
        }
    }
}
