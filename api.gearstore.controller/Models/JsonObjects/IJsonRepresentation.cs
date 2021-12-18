namespace api.gearstore.controller.Models.JsonObjects
{
    public interface IJsonRepresentation<TImage>
    {
        /**
         * Returns original data object with data from json
         */
        TImage ToImage();

        /**
         * Loads data from original data object into fields
         * 
         * Usage:
         * JsonRepresentationSubclass obj = new JsonRepresentationSubclass().Represent(image);
         */
        void Represent(TImage image);
    }
}