namespace OtusCProHomework4.Models
{
    public class F
    {
        // Example fields
        public int i1, i2, i3, i4, i5;

        // Parameterless constructor
        public F()
        {
            // Initialize with default values or leave as default (zero)
        }

        // Constructor that varies the complexity based on the parameter
        public F(int complexityLevel)
        {
            // Basic initialization
            i1 = complexityLevel * 1;
            i2 = complexityLevel * 2;
            i3 = complexityLevel * 3;
            i4 = complexityLevel * 4;
            i5 = complexityLevel * 5;
        }

        // Static method to create an instance of F with a specified complexity level
        public static F Get(int complexityLevel = 1)
        {
            return new F(complexityLevel);
        }
    }
}
