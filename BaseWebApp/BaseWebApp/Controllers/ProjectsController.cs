using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BaseWebApp.Models;

namespace BaseWebApp.Controllers
{
    public class ProjectsController : ApiController
    {
        private ProjectsModel db = new ProjectsModel();

        // GET: api/Projects
        public IQueryable<Projects> GetProjects()
        {
            return db.Projects;
        }

        // GET: api/Projects/5
        [ResponseType(typeof(Projects))]
        public async Task<IHttpActionResult> GetProjects(Guid id)
        {
            Projects projects = await db.Projects.FindAsync(id);
            if (projects == null)
            {
                return NotFound();
            }

            return Ok(projects);
        }

        // PUT: api/Projects/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProjects(Guid id, Projects projects)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projects.ProjectsId)
            {
                return BadRequest();
            }

            db.Entry(projects).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Projects
        [ResponseType(typeof(Projects))]
        public async Task<IHttpActionResult> PostProjects(Projects projects)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Projects.Add(projects);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjectsExists(projects.ProjectsId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = projects.ProjectsId }, projects);
        }

        // DELETE: api/Projects/5
        [ResponseType(typeof(Projects))]
        public async Task<IHttpActionResult> DeleteProjects(Guid id)
        {
            Projects projects = await db.Projects.FindAsync(id);
            if (projects == null)
            {
                return NotFound();
            }

            db.Projects.Remove(projects);
            await db.SaveChangesAsync();

            return Ok(projects);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectsExists(Guid id)
        {
            return db.Projects.Count(e => e.ProjectsId == id) > 0;
        }
    }
}