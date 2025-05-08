namespace BookApp.Domain;

public class Entity<ID>
{
    private ID Id;

    public ID GetId()
    {
        return Id;
    }
    public void SetId(ID id)
    {
        this.Id = id;
    }
}