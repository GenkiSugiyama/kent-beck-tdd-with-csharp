﻿namespace TDD.Money;

public interface Expression
{
    Money Reduce(Bank bank, string to);
}
