using Bogus;

namespace Rusell.Test.Shared.Domain;

public static class MotherCreator
{
  public static Faker<T> Random<T>() where T : class => new();

  public static Randomizer Random() => new Faker().Random;
}