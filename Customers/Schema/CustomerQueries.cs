﻿using Customers.Services;
using GraphQL;
using GraphQL.Types;

namespace Customers.Schema
{
    public class CustomerQueries : ObjectGraphType
    {
        public CustomerQueries(ICustomerService customers)
        {
            Name = "CustomerQueries";
            Field<ListGraphType<CustomerType>>("getAll",
                resolve: ctx => customers.GetCustomersAsync()
            );
            Field<CustomerType>("getById",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "customerId" }),
                resolve: context =>
                {
                    var orderId = context.GetArgument<string>("customerId");
                    return customers.GetCustomerById(orderId);
                });
        }
    }
}
