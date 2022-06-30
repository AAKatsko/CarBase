namespace CarBase
{
    internal class Program
    {
        static void Main()
        {
            using CarsDBContext db = new CarsDBContext();

            var s = Console.ReadLine().Split(" ");
            var company = s[0];
            var model = s[1];
            var power = int.Parse(s[2]);
            var bodyType = s[3];
            var weight = int.Parse(s[4]);
            var prise = int.Parse(s[5]);

            var bt = db.BodyTypeTables.FirstOrDefault(c => c.BodyType == s[3]);
            var bodyTypeId = bt.Id;
            var c = db.CompanyTables.FirstOrDefault(c => c.Company == s[0]);
            var companyId = c.Id;

            CarsTable car = new()
            {
                Company = companyId,
                Power = power,
                Model = model,
                BodyType = bodyTypeId,
                Weight = weight,
                Prise = prise
            };

            db.CarsTables.Add(car);
            db.SaveChanges();
        }
    }
}