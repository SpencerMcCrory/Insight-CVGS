﻿namespace InsightApp.Entities
{
    public class LanguageTable
    {
        // EF Core will configure this to be an auto-incremented primary key:
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }

        // following we are linking with the assocition tables
        public ICollection<MemberLanguagePref>? MemberLanguagePrefs { get; set; }
        public ICollection<GameDetailsLanguage>? GameDetailsLanguages { get; set; }
    }
}
