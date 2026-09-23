using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

namespace TodoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                var authConfig = builder.Configuration.GetSection("AuthConfiguration");
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = authConfig["Issuer"],
                    ValidAudience = authConfig["Audience"],
                    ClockSkew = TimeSpan.FromSeconds(30),
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(authConfig["Key"]))
                };
            });
            builder.Services.AddAuthorization();
            builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            var todoItems = app.MapGroup("/todoitems");

            // Require JWT auth for the group
            todoItems.RequireAuthorization();

            todoItems.MapGet("/", GetAllTodos);
            todoItems.MapGet("/complete", GetCompleteTodos);
            todoItems.MapGet("/{id}", GetTodo);
            todoItems.MapPost("/", CreateTodo);
            todoItems.MapPut("/{id}", UpdateTodo);
            todoItems.MapPatch("/{id}", PatchTodo);
            todoItems.MapDelete("/{id}", DeleteTodo);

            app.Run();

        }

        static async Task<IResult> GetAllTodos(TodoDb db)
        {
            return TypedResults.Ok(await db.Todos.Select(x => new TodoItemDTO(x)).ToArrayAsync());
        }

        static async Task<IResult> GetCompleteTodos(TodoDb db)
        {
            return TypedResults.Ok(await db.Todos.Where(t => t.IsComplete).Select(x => new TodoItemDTO(x)).ToListAsync());
        }

        static async Task<IResult> GetTodo(int id, TodoDb db)
        {
            return await db.Todos.FindAsync(id)
                is Todo todo
                    ? TypedResults.Ok(new TodoItemDTO(todo))
                    : TypedResults.NotFound();
        }

        static async Task<IResult> CreateTodo(TodoItemDTO todoItemDTO, TodoDb db)
        {
            var todoItem = new Todo
            {
                IsComplete = todoItemDTO.IsComplete,
                Name = todoItemDTO.Name
            };

            db.Todos.Add(todoItem);
            await db.SaveChangesAsync();

            todoItemDTO = new TodoItemDTO(todoItem);

            return TypedResults.Created($"/todoitems/{todoItem.Id}", todoItemDTO);
        }

        static async Task<IResult> UpdateTodo(int id, TodoItemDTO todoItemDTO, TodoDb db)
        {
            var todo = await db.Todos.FindAsync(id);

            if (todo is null) return TypedResults.NotFound();

            todo.Name = todoItemDTO.Name;
            todo.IsComplete = todoItemDTO.IsComplete;

            await db.SaveChangesAsync();

            return TypedResults.NoContent();
        }

        static async Task<IResult> PatchTodo(int id, TodoPatchDto inputTodo, TodoDb db)
        {
            var todo = await db.Todos.FindAsync(id);

            if (todo is null) return TypedResults.NotFound();

            if (inputTodo.Name is not null) todo.Name = inputTodo.Name;
            if (inputTodo.IsComplete is not null) todo.IsComplete = inputTodo.IsComplete.Value;

            await db.SaveChangesAsync();

            return TypedResults.NoContent();
        }

        static async Task<IResult> DeleteTodo(int id, TodoDb db)
        {
            if (await db.Todos.FindAsync(id) is Todo todo)
            {
                db.Todos.Remove(todo);
                await db.SaveChangesAsync();
                return TypedResults.NoContent();
            }

            return TypedResults.NotFound();
        }
    }
}
