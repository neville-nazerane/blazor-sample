using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using pusher.Data;
using pusher.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pusher.Pages
{
    public class ProjectsView : ComponentBase
    {

        public Project ProjectToAdd { get; set; }

        public ICollection<Project> Projects { get; set; }

        [Inject]
        public ScopeAccess ScopeAccess { get; set; }

        public AppDbContext Context => ScopeAccess.GetService<AppDbContext>();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            ProjectToAdd = new Project();
            Projects = await Context.Projects.ToListAsync();
            ScopeAccess.ClearScope();
        }

        public async Task AddAsync()
        {
            await Context.AddAsync(ProjectToAdd);
            await Context.SaveChangesAsync();
            Projects.Add(ProjectToAdd);
            ProjectToAdd = new Project();
            ScopeAccess.ClearScope();
        }

        public async Task DeleteAsync(Project project)
        {
            Context.Remove(project);
            await Context.SaveChangesAsync();
            Projects.Remove(project);
            ScopeAccess.ClearScope();
        }

    }
}
