using Base;

namespace Level.Upgrades
{
    public class CropDeliveryUpgrade : BaseUpgrade
    {
        public Vegetable lettuce;
        public Vegetable zucchini;
        public Vegetable carrot;
        public Vegetable tomato;

        public override string GetUpgradeDescription(int level)
        {
            return level switch
            {
                1 => "Plant lettuce, which gives 2x XP",
                2 => "Plant zucchini, which give 3x XP",
                3 => "Plant carrot, which give 4x XP",
                4 => "Plant tomato, which give 5x XP",
                _ => "-"
            };
        }

        protected override void Apply()
        {
            switch (Level)
            {
                case 1: // Plant lettuce, which gives 2x XP
                    Stats.Instance.cropToBePlanted = lettuce;
                    sprite = zucchini.sprites[3];
                    break;
                
                case 2: // Plant zucchini, which give 3x XP
                    Stats.Instance.cropToBePlanted = zucchini;
                    sprite = carrot.sprites[3];
                    break;
                
                case 3: // Plant carrot, which give 4x XP
                    Stats.Instance.cropToBePlanted = carrot;
                    sprite = tomato.sprites[3];
                    break;
                
                case 4: // Plant tomato, which give 5x XP
                    Stats.Instance.cropToBePlanted = tomato;
                    break;
            }
        }
    }
}