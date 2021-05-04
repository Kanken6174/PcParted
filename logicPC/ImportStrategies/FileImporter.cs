using System.Linq;

namespace logicPC
{
    public class FileImporter
    {
        private IManagerImportation _strategy;  //représente la stratégie actuelle, peut être changé
        private string filePath;

        public FileImporter()
        {
            filePath = "";
        }

        /// <summary>
        /// FileImporter choisit la stratégie à adopter pour traiter le fichier, en fonction de son extension
        /// </summary>
        /// <param name="filePath"></param>
        public object Import(string filePathext)
        {
            this.filePath = filePathext;

            IManagerImportation strategy = new SImporterDataSets();
            this._strategy = strategy;
            string extension = filePath.Split('.').Last();     //récupère l'extension, peut être .pem(images) .pnm(datasets) ou .usl(userLists)
            switch (extension)
            {
                case "pem":
                    this._strategy = new SImporterPictureLink();
                    break;
                case "pnm":
                    this._strategy = new SImporterDataSets();
                    break;
                case "usl":
                    this._strategy = new SImporterUserLists();
                    break;
                default:
                    break;
            }

            return this._strategy.FileImportOP(filePath);
        }

        public void SetStrategy(IManagerImportation strategy)   //remplace la stratégie utilisée
        {
            this._strategy = strategy;
        }

    }

}
