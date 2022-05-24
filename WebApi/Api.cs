namespace WebApi
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/Users", GetUsers);
            app.MapGet("/Users/{id}", GetUser);
            app.MapPost("/Users", InsertUser);
            app.MapPut("/Users", UpdateUser);
            app.MapDelete("/Users", DeleteUser);
            app.MapGet("/error", GetError);
        }

        private static async Task GetError()
        {
            throw new ArgumentNullException("CustomError");
        }

        private static async Task<IResult> GetUsers(IUserData data)
        {
            try
            {
                return Results.Ok(await data.GetUsers());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);

            }

        }

        private static async Task<IResult> GetUser(int id, IUserData data)
        {
            try
            {
                var results = await data.GetUser(id);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);

            }
        }

        private static async Task<IResult> InsertUser(UserModel user, IUserData data, IMinimalValidator minimalValidator)
        {
            try
            {
                var validationResult = minimalValidator.Validate(user);
                if (validationResult.IsValid)
                {
                    await data.InsertUser(user);
                    return Results.Ok();
                }
                return Results.ValidationProblem(validationResult.Errors);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);

            }
        }
        private static async Task<IResult> UpdateUser(UserModel user, IUserData data, IMinimalValidator minimalValidator)
        {
            try
            {
                var validationResult = minimalValidator.Validate(user);
                if (validationResult.IsValid)
                {
                    await data.UpdateUser(user);
                    return Results.Ok();
                }
                return Results.ValidationProblem(validationResult.Errors);

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);

            }
        }

        private static async Task<IResult> DeleteUser(int id, IUserData data)
        {
            try
            {
                await data.DeleteUser(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);

            }
        }
    }
}
