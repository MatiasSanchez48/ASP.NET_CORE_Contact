using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.ContactsApi.Models;

namespace NetCore.ContactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        List<Contact> contacts = new List<Contact>
        {
            new Contact{
                CreatedAt = DateTime.Now,
                Email = "dumby@gmail.com",
                FirstName = "rodigo",
               Id =  Guid.NewGuid().ToString(),
               LastName = "sanchez",
               PhoneNumber = "1234567890",
               UpdatedAt = DateTime.Now,
            }
            ,
             new Contact{
                CreatedAt = DateTime.Now,
                Email = "matias@gmail.com",
                FirstName = "matias",
               Id =  Guid.NewGuid().ToString(),
               LastName = "sanchez",
               PhoneNumber = "0910219",
               UpdatedAt = DateTime.Now,
            }
            , new Contact{
                CreatedAt = DateTime.Now,
                Email = "diego@gmail.com",
                FirstName = "diego",
               Id =  Guid.NewGuid().ToString(),
               LastName = "sanchez",
               PhoneNumber = "271389107",
               UpdatedAt = DateTime.Now,
            }
            , new Contact{
                CreatedAt = DateTime.Now,
                Email = "jaime23@gmail.com",
                FirstName = "jaime rondon",
               Id =  Guid.NewGuid().ToString(),
               LastName = "gutierrez",
               PhoneNumber = "019230193",
               UpdatedAt = DateTime.Now,
            }
            , new Contact{
                CreatedAt = DateTime.Now,
                Email = "jorge@gmail.com",
                FirstName = "thiago",
               Id =  Guid.NewGuid().ToString(),
               LastName = "alvarez",
               PhoneNumber = "018293213719",
               UpdatedAt = DateTime.Now,
            }
            ,
        };

        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(string id)
        {
            try
            {
                Contact contact = contacts.FirstOrDefault(c => c.Id == id);

                if (contact == null) return BadRequest("Contact not found");

                return Ok(contact);
            }
            catch (Exception ex)
            {
                return BadRequest("Error to search contact" + ex.Message);
            }

        }
        [HttpPost]
        public IActionResult CreateContact([FromBody] Contact contact)
        {
            try
            {
                if (contact.Email == null || contact.FirstName == null || contact.LastName == null || contact.PhoneNumber == null)
                    return BadRequest("Review field");
                contact.Id = Guid.NewGuid().ToString();
                contacts.Add(contact);

                return Ok("Created Success");
            }
            catch (Exception ex)
            {
                return BadRequest("Error to create new contact" + ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult ModifyContact(string id, [FromBody] Contact contact)
        {
            try
            {
                Contact modifiedContact = contacts.FirstOrDefault(c => c.Id == id);

                if (modifiedContact == null) return BadRequest("Contact not found");

                modifiedContact.Email = contact.Email;
                modifiedContact.FirstName = contact.FirstName;
                modifiedContact.LastName = contact.LastName;
                modifiedContact.PhoneNumber = contact.PhoneNumber;
                modifiedContact.UpdatedAt = DateTime.Now;

                return Ok(modifiedContact);

            }
            catch (Exception ex)
            {
                return BadRequest("Error to modify or found contact" + ex.Message);
            }

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(string id)
        {
            try
            {

                Contact deleteContact = contacts.FirstOrDefault(c => c.Id == id);
                if (deleteContact == null) return BadRequest("Contact not found");

                contacts.Remove(deleteContact);

                return Ok("Contact remove success");
            }
            catch (Exception ex)
            {
                return BadRequest("Error to Delete or Found contact" + ex.Message);
            }
        }
    }
}
