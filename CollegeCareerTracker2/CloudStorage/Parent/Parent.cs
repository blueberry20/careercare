using Microsoft.WindowsAzure.Storage.Table;
using System;
using static CollegeCareerTracker2.Enums.Enums;

namespace CollegeCareerTracker2.CloudStorage.Parent
{
    public class Parent : TableEntity
    {
        public Parent()
        {
            PartitionKey = "Parent";
            RowKey = Guid.NewGuid().ToString();
        }

        public int AptitudeValue { get; set; }
        [IgnoreProperty]
        public AnswerOptionsEnum Aptitude {
            get
            {
                return (AnswerOptionsEnum)AptitudeValue;
            }
            set
            {
                AptitudeValue = (int)value;
            }
        }
        public int CareerExplorationValue { get; set; }
        [IgnoreProperty]
        public AnswerOptionsEnum CareerExploration
        {
            get
            {
                return (AnswerOptionsEnum)CareerExplorationValue;
            }
            set
            {
                CareerExplorationValue = (int)value;
            }
        }
        public int CareerRoadMapDevelopmentValue { get; set; }
        [IgnoreProperty]
        public AnswerOptionsEnum CareerRoadMapDevelopment {
            get
            {
                return (AnswerOptionsEnum)CareerRoadMapDevelopmentValue;
            }
            set
            {
                CareerRoadMapDevelopmentValue = (int)value;
            }
        }
        public int StudentAchievementArchiveValue { get; set; }
        [IgnoreProperty]
        public AnswerOptionsEnum StudentAchievementArchive {
            get
            {
                return (AnswerOptionsEnum)StudentAchievementArchiveValue;
            }
            set
            {
                StudentAchievementArchiveValue = (int)value;
            }
        }
        public int CollegeSelectionOptimizerValue { get; set; }
        [IgnoreProperty]
        public AnswerOptionsEnum CollegeSelectionOptimizer {
            get
            {
                return (AnswerOptionsEnum)CollegeSelectionOptimizerValue;
            }
            set
            {
                CollegeSelectionOptimizerValue = (int)value;
            }
        }
        public int CollegeAdmissionSchedulerValue { get; set; }
        [IgnoreProperty]
        public AnswerOptionsEnum CollegeAdmissionScheduler {
            get
            {
                return (AnswerOptionsEnum)CollegeAdmissionSchedulerValue;
            }
            set
            {
                CollegeAdmissionSchedulerValue = (int)value;
            }
        }
        public int CareerRewardsValue { get; set; }
        [IgnoreProperty]
        public AnswerOptionsEnum CareerRewards {
            get
            {
                return (AnswerOptionsEnum)CareerRewardsValue;
            }
            set
            {
                CareerRewardsValue = (int)value;
            }
        }
        public int HabitBuilderValue { get; set; }
        [IgnoreProperty]
        public AnswerOptionsEnum HabitBuilder {
            get
            {
                return (AnswerOptionsEnum)HabitBuilderValue;
            }
            set
            {
                HabitBuilderValue = (int)value;
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string NumberOfStudents { get; set; }
        public string StudentGradesArray { get; set; }
        public int PaymentPreferenceValue { get; set; }
        [IgnoreProperty]
        public PaymentPreferencesEnum PaymentPreference {
            get
            {
                return (PaymentPreferencesEnum)PaymentPreferenceValue;
            }
            set
            {
                PaymentPreferenceValue = (int)value;
            }
        }
    }
}