using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net10.Mvc.IssueBoard.Data;
using Net10.Mvc.IssueBoard.Models;
using Net10.Mvc.IssueBoard.Models.ViewModels;

namespace Net10.Mvc.IssueBoard.Controllers
{
    public class IssueBoardController : Controller
    {
        private readonly IssuesDbContext _context;

        public IssueBoardController(IssuesDbContext context)
        {
            _context = context;
        }

        // GET: IssueBoard
        public async Task<ActionResult> Index()
        {
            var issues = await _context.Issues
                .OrderByDescending(i => i.CreatedAt)
                .Select(i => new IssueListViewModel
                {
                    Id = i.Id,
                    AuthorName = i.AuthorName,
                    CreatedAt = i.CreatedAt,
                    Category = i.Category,
                    Title = i.Title,
                    Status = (IssueStatus)i.Status,
                    ResolverName = i.ResolverName,
                    ResolvedAt = i.ResolvedAt
                })
                .ToListAsync();

            return View(issues);
        }

        // GET: IssueBoard/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var issue = await _context.Issues.FindAsync(id);

            if (issue == null)
            {
                return NotFound();
            }

            var viewModel = new IssueDetailViewModel
            {
                Id = issue.Id,
                AuthorName = issue.AuthorName,
                CreatedAt = issue.CreatedAt,
                Category = issue.Category,
                Title = issue.Title,
                Description = issue.Description,
                Status = (IssueStatus)issue.Status,
                Resolution = issue.Resolution,
                ResolverName = issue.ResolverName,
                ResolvedAt = issue.ResolvedAt
            };

            return View(viewModel);
        }

        // GET: IssueBoard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IssueBoard/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IssueCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var issue = new Issue
                {
                    AuthorName = viewModel.AuthorName,
                    CreatedAt = DateTime.Now,
                    Category = viewModel.Category,
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    Status = (int)IssueStatus.NotStarted,
                    Resolution = string.Empty,
                    ResolverName = string.Empty,
                    ResolvedAt = null
                };

                _context.Issues.Add(issue);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        // GET: IssueBoard/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var issue = await _context.Issues.FindAsync(id);

            if (issue == null)
            {
                return NotFound();
            }

            var viewModel = new IssueEditViewModel
            {
                Id = issue.Id,
                AuthorName = issue.AuthorName,
                CreatedAt = issue.CreatedAt,
                Category = issue.Category,
                Title = issue.Title,
                Description = issue.Description,
                Status = (IssueStatus)issue.Status,
                Resolution = issue.Resolution,
                ResolverName = issue.ResolverName,
                ResolvedAt = issue.ResolvedAt
            };

            return View(viewModel);
        }

        // POST: IssueBoard/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IssueEditViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var issue = await _context.Issues.FindAsync(id);

                if (issue == null)
                {
                    return NotFound();
                }

                issue.Category = viewModel.Category;
                issue.Title = viewModel.Title;
                issue.Description = viewModel.Description;
                issue.Status = (int)viewModel.Status;
                issue.Resolution = viewModel.Resolution;
                issue.ResolverName = viewModel.ResolverName;
                issue.ResolvedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Details), new { id = issue.Id });
            }

            return View(viewModel);
        }

        // GET: IssueBoard/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var issue = await _context.Issues.FindAsync(id);

            if (issue == null)
            {
                return NotFound();
            }

            var viewModel = new IssueDetailViewModel
            {
                Id = issue.Id,
                AuthorName = issue.AuthorName,
                CreatedAt = issue.CreatedAt,
                Category = issue.Category,
                Title = issue.Title,
                Description = issue.Description,
                Status = (IssueStatus)issue.Status,
                Resolution = issue.Resolution,
                ResolverName = issue.ResolverName,
                ResolvedAt = issue.ResolvedAt
            };

            return View(viewModel);
        }

        // POST: IssueBoard/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var issue = await _context.Issues.FindAsync(id);

            if (issue != null)
            {
                _context.Issues.Remove(issue);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
