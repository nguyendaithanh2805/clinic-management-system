namespace clinic_management_system.Common
{
    public static class IdGenerator
    {
        public static int GenerateUniqueId()
        {
            DateTime time = DateTime.Now;
            var hour = time.Hour.ToString("D2");
            var minute = time.Minute.ToString("D2");
            var second = time.Second.ToString("D2");
            var id = $"{hour}{minute}{second}";
            return int.Parse(id);
        }
    }
}
