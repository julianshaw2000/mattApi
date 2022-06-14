namespace api.Models
{
    public record User
    {
        public User()
        {
            this.Id = Guid.NewGuid();
        }
        // public Guid Id { get; set; }
        public Guid Id { get; init; }

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; }= default!;

        public string Email { get; set; }= default!;
        public string Phone { get; set; }= default!;
        public string Address { get; set; }= default!;
        public string Message { get; set; }= default!;
    }
}
