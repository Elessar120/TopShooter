public class WeaponModel : Element
{
    public float FireRate { get; private set; }
    public int Magazine { get; private set; }
    public bool CanFire { get; private set; }
   
    
    public WeaponModel(float fireRate, int magazine)
    {
        FireRate = fireRate;
        Magazine = magazine;
        CanFire = true;
    }

    public void SetCanFire(bool value)
    {
        CanFire = value;
    }
}