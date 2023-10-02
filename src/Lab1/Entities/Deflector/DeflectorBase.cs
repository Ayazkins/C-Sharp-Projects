using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public abstract class DeflectorBase
{
    protected DeflectorBase(int maxHitPoints, bool photonDeflectorHitPoints = false)
    {
        CurrentHitPoints = maxHitPoints;
        PhotonDeflectorHitPoints = photonDeflectorHitPoints ? 3 : 0;
    }

    public bool IsAlive => this.CurrentHitPoints > 0;
    public int CurrentHitPoints { get; private set; }

    public int PhotonDeflectorHitPoints { get; private set; }

    public void TakeDamage(ObstacleBase? obstacle)
    {
        if (obstacle == null)
        {
            return;
        }

        if (obstacle is AntiMateria)
        {
            if (PhotonDeflectorHitPoints > 0)
            {
                PhotonDeflectorHitPoints -= 1;
                if (PhotonDeflectorHitPoints < 0)
                {
                    PhotonDeflectorHitPoints = 0;
                }

                obstacle.RefuseDamage(1);
            }

            return;
        }

        int beforeBattle = CurrentHitPoints;

        CurrentHitPoints -= obstacle.Damage;

        if (CurrentHitPoints < 0)
        {
            CurrentHitPoints = 0;
        }

        obstacle.RefuseDamage(beforeBattle);
    }
}