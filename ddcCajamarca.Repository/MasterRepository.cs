namespace ddcCajamarca.Repository
{
    public abstract class MasterRepository
    {
        private ddcCajamarcaContext _context;

        public MasterRepository()
        {
            if (_context == null)
                _context = new ddcCajamarcaContext();
        }

        protected ddcCajamarcaContext Context
        {
            get { return _context; }
        }
    }
}
