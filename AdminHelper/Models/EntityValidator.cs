using AdminHelper.models.entities;

namespace AdminHelper.Models
{
    public static class EntityValidator
    {
        public static bool IsValid(this Actor actor)
        {
            var isLastName = !string.IsNullOrWhiteSpace(actor.LastName) && actor.LastName.Length <= 50;
            var isFirstName = !string.IsNullOrWhiteSpace(actor.FirstName) && actor.FirstName.Length <= 50;
            var isPatronymic = !string.IsNullOrWhiteSpace(actor.Patronymic) && actor.Patronymic.Length <= 50;

            return isLastName && isFirstName && isPatronymic;
        }

        public static bool IsValid(this Fullness fullness)
        {
            var isFullnessName = !string.IsNullOrWhiteSpace(fullness.FullnessName) && fullness.FullnessName.Length <= 70;
            var isAllowance = fullness.Allowance >= 0;

            return isFullnessName && isAllowance;
        }

        public static bool IsValid(this Role role)
        {
            var isRate = role.Rate != null && role.Rate >= 0;
            return isRate;
        }

        public static bool IsValid(this RoleType roleType)
        {
            var isName = !string.IsNullOrWhiteSpace(roleType.Name) && roleType.Name.Length <= 30;
            return isName;
        }

        public static bool IsValid(this Spectacle spectacle)
        {
            var isName = !string.IsNullOrWhiteSpace(spectacle.Name) && spectacle.Name.Length <= 70;
            var isDate = spectacle.Date != null;
            return isName && isDate;
        }
    }
}
