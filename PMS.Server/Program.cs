
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using PMS.Server.Exceptions;
using PMS.Server.Extensions;
using PMS.Server.Middlewares;
using PMS.Server.Responses;

namespace PMS.Server
{
    /// <summary>
    /// ������� ����� ����������, ���������� ����� ����� � ������������ ���-�������.
    /// </summary>
    /// <remarks>
    /// <para>
    /// ����������� � ��������� ���-���������� ASP.NET Core � REST API, ��������� ��������� ������������:
    /// </para>
    /// <list type="bullet">
    /// <item><description>�������������� ������������� JSON ��� ������������� ������� ������ API</description></item>
    /// <item><description>�������������� ����������� Swagger � ����� ����������</description></item>
    /// <item><description>����������� ���� ����������� �������� (���� ������, �����������, MediatR, AutoMapper)</description></item>
    /// </list>
    /// </remarks>
    public class Program
    {
        /// <summary>
        /// ����� ����� � ����������.
        /// </summary>
        /// <param name="args">������ ����������, ������������ ��� ������� ����������.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // �������� �������
            builder.Services.AddControllers(options =>
            {
                // �������� �������������� �������� ������
                options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
                options.OutputFormatters.RemoveType<StreamOutputFormatter>();
                options.OutputFormatters.RemoveType<StringOutputFormatter>();

                // ����������� ������� JSON
                var jsonFormatter = options.OutputFormatters.OfType<SystemTextJsonOutputFormatter>().First();
                options.OutputFormatters.Clear();
                options.OutputFormatters.Add(jsonFormatter);

                // ����� �������� ������� application/json
                options.Filters.Add(new ProducesAttribute("application/json"));
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // ����������� ��������
            builder.Services
                .AddCustomValidation()
                .AddDatabaseConfiguration(builder.Configuration)
                .AddRepositories()
                .AddMediatRConfiguration()
                .AddAutoMapperWithValidation(builder.Environment)
                .AddSwaggerDocumentation();

            // ���������� ����������� ��������� �� ������
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressMapClientErrors = true;
                options.InvalidModelStateResponseFactory = context =>
                {
                    // �������� ������ �� ModelState
                    var errors = context.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                        );

                    // ������� ��������� ���������� � �������� ���������
                    throw new BadRequestException("������ ���������", errors);
                };
            });

            var serviceProvider = builder.Services.BuildServiceProvider();
            var validators = serviceProvider.GetServices<IValidator>();

            Console.WriteLine("������������������ ����������:");
            foreach (var validator in validators)
            {
                Console.WriteLine(validator.GetType().FullName);
            }

            // ���������� ����������
            var app = builder.Build();

            // ������������ middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerDocumentation();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            //app.UseRouting(); ?

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
