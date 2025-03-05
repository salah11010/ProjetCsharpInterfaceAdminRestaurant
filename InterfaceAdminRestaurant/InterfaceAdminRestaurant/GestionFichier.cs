using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace InterfaceAdminRestaurant
{
    public class GestionFichierJson
    {
        private readonly string filePath;

        public GestionFichierJson(string filePath)
        {
            this.filePath = filePath;
        }

        public bool Exists()
        {
            return File.Exists(filePath);
        }

        public ConteneurArticles Read()
        {
            if (!Exists())
                throw new GestionFichierException("Le fichier n'existe pas.", filePath);

            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<ConteneurArticles>(jsonString);
        }

        public void Write(ConteneurArticles content)
        {
             string jsonString = JsonSerializer.Serialize(content, new JsonSerializerOptions { WriteIndented = true });
             File.WriteAllText(filePath, jsonString);
        }

        public void Append(ConteneurArticles content)
        {
            if (!Exists())
            {
                Write(content);
            }
            else
            {
                string jsonString = File.ReadAllText(filePath);
                ConteneurArticles existingData = JsonSerializer.Deserialize<ConteneurArticles>(jsonString);

                // Vérifier si chaque liste contient des éléments avant d'ajouter
                if (content.Nouritures != null && content.Nouritures.Count > 0)
                    existingData.Nouritures.AddRange(content.Nouritures);

                if (content.Boissons != null && content.Boissons.Count > 0)
                    existingData.Boissons.AddRange(content.Boissons);

                if (content.Frites != null && content.Frites.Count > 0)
                    existingData.Frites.AddRange(content.Frites);

                if (content.Menus != null && content.Menus.Count > 0)
                    existingData.Menus.AddRange(content.Menus);

                // Réécriture du fichier JSON avec les nouvelles données
                Write(existingData);
            }
        }


        public void Delete()
        {
            if (Exists())
            {
                File.Delete(filePath);
            }
        }
    }
}
