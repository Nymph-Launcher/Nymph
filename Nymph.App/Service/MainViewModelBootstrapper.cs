﻿using System.Windows.Data;
using Nymph.Model.Strategy;
using Nymph.Shared.ViewModel;
using LanguageExt;
using static LanguageExt.Prelude;
using Nymph.Model.Item;
using Nymph.Plugin.Everything;
using Nymph.Plugin.GitHub;
using Nymph.Plugin.JQ;
using static LanguageExt.Prelude;
using Binding = Nymph.Model.Binding;

namespace Nymph.App.Service;

public static class MainViewModelBootstrapper
{
    public static MainViewModel CreateMainViewModel()
    {
        return new MainViewModel([
            new Binding("Everything", FileSearch.CreateEverythingSearchItem()),
            new Binding("Everything: Open File from FileInfo", FileSearch.CreateOpenFileItem()),
            new Binding("Everything: Open File's Directory from FileInfo", FileSearch.CreateOpenDirItem()),
            new Binding("Search under Directory", FileSearch.CreateFileSearchItem()),
            
            new Binding("Github: Search Repository", SearchRepository.CreateSearchRepositoryItem()),
            new Binding("GitHub: Open Repository", SearchRepository.CreateOpenRepositoryItem()),
            new Binding("GitHub: Search Code in Repo", SearchCode.CreateSearchCodeItem()),
            
            new Binding("JQ: Parse JSON", JsonQuery.CreateParseJsonItem()),
            new Binding("JQ: Update JSON with JQ query", JsonQuery.CreateUpdateJsonItem()),
           
        ], new SynthesisStrategy());
    }
}