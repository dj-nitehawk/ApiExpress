﻿namespace TestCases.FormBindingComplexDtos;

sealed class Book
{
    public string Title { get; set; }
    public IFormFile CoverImage { get; set; }
    public IFormFileCollection SourceFiles { get; set; }
    public Author MainAuthor { get; set; }
    public List<Author> CoAuthors { get; set; }
}

sealed class Author
{
    public string Name { get; set; }
    public IFormFile ProfileImage { get; set; }
    public IFormFileCollection DocumentFiles { get; set; }
    public Address MainAddress { get; set; }
    public List<Address> OtherAddresses { get; set; }
}

sealed class Address
{
    public string Street { get; set; }
    public IFormFile MainImage { get; set; }
    public IFormFileCollection AlternativeImages { get; set; }
}

sealed class Endpoint : Endpoint<Book>
{
    internal static Book? Result { get; private set; }

    public override void Configure()
    {
        Post("test-cases/form-binding-complex-dtos");
        AllowAnonymous();
        AllowFileUploads();
    }

    public override Task HandleAsync(Book r, CancellationToken ct)
    {
        Result = r;

        return Task.CompletedTask;
    }
}