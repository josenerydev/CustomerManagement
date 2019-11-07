﻿using CSharpFunctionalExtensions;

using System;
using System.Collections.Generic;

namespace CustomerManagement.Logic.Model
{
    public class EmailingSettings : ValueObject
    {
        public Industry Industry { get; }
        public bool EmailingIsDisabled { get; }
        public EmailCampaign EmailCampaign => GetEmailCampaign(Industry, EmailingIsDisabled);

        private EmailingSettings()
        {
        }

        public EmailingSettings(Industry industry, bool emailingIsDisable)
            : this()
        {
            Industry = industry;
            EmailingIsDisabled = emailingIsDisable;
        }

        public EmailingSettings DisableEmailing()
        {
            return new EmailingSettings(Industry, true);
        }

        public EmailingSettings ChangeIndustry(Industry industry)
        {
            return new EmailingSettings(industry, EmailingIsDisabled);
        }

        private EmailCampaign GetEmailCampaign(Industry industry, bool emailingIsDisabled)
        {
            if (emailingIsDisabled)
                return EmailCampaign.None;

            if (industry == Industry.Cars)
                return EmailCampaign.LatestCarModels;

            if (industry == Industry.Pharmacy)
                return EmailCampaign.PharmacyNews;

            if (industry == Industry.Other)
                return EmailCampaign.Generic;

            throw new ArgumentException();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Industry;
            yield return EmailingIsDisabled;
        }
    }
}
