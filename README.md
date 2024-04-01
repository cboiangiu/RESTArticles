# RESTArticles

## Assumptions

- Limits have been imposed in regard to the `title` and `content` length. These have been chosen based on the average blog post [title](https://sheknowsseo.co/blog-post-title-length/) and [content](https://www.wix.com/blog/how-long-should-a-blog-post-be) word counts. The average English language word length is [4.7 characters](https://www.wyliecomm.com/2021/11/whats-the-best-length-of-a-word-online).
- Only the `title` and `content` fields are allowed to change in regard to updating the article. The `publishedDate` should remain the same since that's the date the article got created.
- Authorization requirements have been added for the `create`, `update` and `delete` endpoints, leaving only the `get` ones available for the public users.

## Design decisions

- The `DAL`, `services` and `other various classes` have been separated from the main API project to facilitate reuse in other potential APIs/microservices in the future.
- `Interfaces` have been used for the injected services to facilitate testing/mocking.
- `EF migrations` have been used to accommodate entity changes down the road.
- The `repository` design pattern has been used to abstract data access away from the application's core logic to improve testability and flexibility.
- `Services` have been used to encapsulate business logic, promote code reusability, SoC and testability.
- A `ServiceResult` abstraction has been used in order to make error handling more predictable.
- The `validation` for the entities has been encapsulated within the setters in order to keep the validation business logic as close to the entity as possible.
- `Custom exceptions` have been created to handle various errors and error messages.
- `DTOs` have been used to provide the client with appropriate data, have control over data exposure, decouple data from the internal data models and even facilitate versioning in the future.