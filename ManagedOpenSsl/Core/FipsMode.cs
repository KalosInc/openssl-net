
namespace OpenSSL.Core
{
    public static class FipsMode
    {
        public static int Set(int mode)
        {
            return Native.FIPS_mode_set(mode);
        }

        public static int Get()
        {
            return Native.FIPS_mode();
        }
    }
}
