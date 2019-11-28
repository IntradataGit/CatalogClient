Welcome to IntraData's Digital Catalog client
=============================

## Getting started ##
In this document we will describe a simple client library to communicate with [**Digital Catalog**](https://www.solipsisdocumentmanagement.nl/intraoffice-archief/), 
a Cloud-based paperless office solution from [**IntraData**](http://intradata.nl). We will go through the possible use cases and present corresponding code examples. 

* [Introduction](#introduction-)


* [Major concepts](#majorconcepts)
  * [Document](#document)
  * [Element](#element)
  * [Document class](#documentclass)
  * [Document category](#documentcategory)


  * [Connecting to Digital Catalog](#ctdc)


* [Basic operations](#basicoperations)
  * [List supported elements](#lse)
  * [List supported document classes](#lsdclasses)
  * [List supported document categories ](#lsdcategories)
  * [Get document retention plans](#gdrp)


* [Working with documents](#wwd)
    * [Adding new document](#and)
    * [Read document's content](#rdc)
    * [Read document's metadata](#rdm)
    * [Create document's version](#cdv)
    * [List document's versions](#ldv)
    * [Remove document version](#rdv)
    * [Update document's metadata](#udm)
    * [Remove document](#rd)
    * [Document events](#de)
    * [Document annotations](#da)


* [Document queries](#documentqueries)
    * [Find documents by text](#fdbt)
    * [Get query result metadata](#gqrm)
    * [Get all rows](#gar)
    * [Get specific row](#gsrow)
    * [Get specific rows](#gsrows)
    * [Changing sort order](#cso)
    * [Using custom query](#ucq)


* [Entities](#entities)
    * [List available entities](#listentities)
    * [Searching for documents using entity](#sfdue)


* [Views](#views)
    * [List available views](#lav)
    * [Find documents using views](#vdbvn)


## Introduction [](#introduction)

[**Digital Catalog**](https://www.solipsisdocumentmanagement.nl/intraoffice-archief/) is an online Cloud-based document management platform aimed 
to help companies to organize and automate their document flow. **Digital Catalog** offers an innovative solution that creates a reliable work environment that every business
can rely on in their transition to `fully digital paper-free` office. **Digital Catalog** is developed by [IntraData](http://intradata.nl) and 
is available to **IntraData's** registered partners via `SAAS` scheme. In short, **Digital Catalog** has the following characteristics: 

*  Possibility to work with private (intranet) and web Clouds (internet)
*  Possibility to manage documents via UI or REST API
*  Support of multiple document versions
*  Possiblity to add accompanying information to documents
*  Possibility to integrate with client backoffice (only private clouds)
*  Possiblity to perform document queries
*  Different possibilities to organize documents
*  Support of advanced security scenarios


## Major concepts [](#basicoperations)

### Document [](#document)

**Digital Catalog** allows to store not only document files but also the related accompanying information. The latter we will referre to as `document metadata`. 
The metadata will be stored in the form of name/value pairs. A good example will be, for example, a customer number that the document is related to. For simplicity, we will refer to the document file 
together with its metadata as simply `Document`. 


### Element [](#element)

When working with free-format name/value dictionaries there is always a risk of typo's or invalid data format. In contrast, 
we want to be sure that the following requirements are met:

* key names are consistent
* key values are in the correct format
* all required keys are present

When someone adds/updates document we want to be sure that all of those constrains are not violated. For this purpose
 we introduce the concept of `Element`. Element has the name which replaces the key in the name/value dictionary. In addition, the element 
 will also contain information about the data type and data format, the provided value must adhere to. The element can also be marked as optional or read-only. 
 The latter implies that the elements, once created, can no longer be updated. In that sense, `Element` is similar to a database column. The document metadata
 will now be presented as a collection of element / element value pairs. 
 
 Its worth to mention that the element's name, type and other contraints are fully defined by the business domain. Element represents an item that is meaningful 
 to the customer's business. And of course, each customer will have own set of elements to work with. 

 ### Document class [](#documentclass)

 Be aware that some of the elements can be required for one sort of document, but can be optional for another. Plus, when creating new document we want to be sure
 that only those elements that are relevant for given document sort can be used in the metadata. To enable this, we introduce a new concept of `Document Class`. 
Document class makes explicit: 
* what elements are allowed for documents that belong to this class
* what elements are optional/required for documents in this class

When adding new document to Catalog it is therefore required to identify which document clas should be used for validation. It is not possible for documents to 'change' their 
document class after their creation in Catalog.

### Document category [](#documentcategory)

It is important to point out that the documents that 'share' the same document class (say, HR related documents) may still be of different sorts and have different purposes. In order
to be able to distinguish between them, we introduce another new concept of `Document Category`. In simple words, document category is a document sort within document class. 
For example, document class 'HR documents' might have the following document categories: "job contract", "employee's performance review", etc. Each document class should 
specifiy at least one document category. When adding new documents to Catalog, it is required to select one of the avalable categories in the selected class. Similar to document class, 
document is not allowed to change its category after it is added to Catalog. 


 ## Connecting to Digital Catalog []("#ctdc") 

The goal of the client library is to make use of the **Digital Catalog** as simple as possible. The client library is the client for Catalog's REST API and is designed to hide all 
`HTTP` related code from the caller. Calling one of the **Digital Catalog**'s methods should be as easy as calling a method on a 'local' class. The client consits of five servies: 

*  `CatalogClient4Config` - service to read Catalog's configuration
*  `CatalogClient4Documents` - service to work with documents
*  `CatalogClient4DocumentQueries` - service to run document queries
*  `CatalogClient4EntityQueries`- service to run entity queries
*  `CatlogClient4Views` - service to work with views

These services require the following settings:
*  `ApiUrl` - URL address of Digital Catalog API (required)
*  `AuthToken` - authorization token (JWT, optional)
*  `TenantId` - name of the tenant (optional)

Here `AuthToken` is a JWT token that contains information about the user on behalf of which the connection should be opened. This token contains digital signature to 
prevent its tampering by a malicious party. It is always required in the web cloud case to ensure that no sensible data is displayed to unauthorized users. In case of 
private clouds (intranet) and all users having the same access rights, the Catalog may be configured in such a way where that token will not be required. 

The last paramer `TenantId` allows to introduce data seggregation even in a private cloud. It represents an organizational 
unit within a company. Documents created and owned by that unit may be configured to be unaccesable to users from another unit. 



## Basic operations [](#basicoperations)

In this section, we will describe basic operations one can be aware of before starting working with Digital Catalog. 


### List supported elements [](#lse)###

In the example code below, we show how to get the overview of available elements:

```
ICatalogClient4Configs service = new CatalogClient4Configs(Settings);

IEnumerable<ElementVm> elements = await service.GetElements();
```

With example result:

```
[
   {
      "Id": "a-documentSize",
      "Title": "Size in bytes",
      "Type": "number",
      "IsReadOnly": true,
      "Validation": 
      {
         "Maximum": 2147483647,
         "Minimum": 0,
         "ExclusiveMaximum": false,
         "ExclusiveMinimum": false,
         "TotalDigits": 9,
         "Enumeration": null
      }
   },
   {
      "Id": "a-documentAnnotated",
      "Title": "Annotated",
      "Type": "boolean",
      "IsReadOnly": true
   },
   {
      "Id": "d-klantnummer",
      "Title": "Klantnummer",
      "Type": "string",
      "IsReadOnly": true,
      "Validation": 
      {
         "MaxLength": 7,
         "MinLength": 0,
         "Pattern": null
      }
   },

   ...
]

```

Every element in the result colleciton corresponds to an element. Each having the following attributes: 
*  `Id` - element's unique identifier
*  `Title` - user friendly name
*  `Type` - element's type 
*  `IsReadOnly` - indicates whether element value can be changed after document is created
*  `Validation` - describes additional constrains for element values (optional)


### List supported document classes [](#lsdclasses)

Here we show how to get the overview of available document classes:

```
ICatalogClient4Configs service = new CatalogClient4Configs(Settings);

IEnumerable<ClassVm> classes = await service.GetClasses();
```

Here is example result:

```
[
   {
      "Id": "hr-dossierDienstverband",
      "Title": "dossierDienstverband",
      "Elements": 
         [
            {
               "Element": "hr-bronsysteem",
               "Use": "Mandatory"
            }, 
            {
               "Element": "hr-medewerkerGeboortedatum",
               "Use": null
            }, 
            {
               "Element": "hr-afdeling",
               "Use": null
            }, 
            {
               "Element": "hr-medewerkerActNaam",
               "Use": null
            }, 
            {
               "Element": "hr-ingangsDatum",
               "Use": "Mandatory"
            }, 
            {
               "Element": "l-documentDispositionDate",
               "Use": null
            },

            ...
         ],
   },

   ...
]
```
As one can see in the response, each document class has the following attributes: 
*  `Id` - class' unique identifier
*  `Title` - user friendly name
*  `Elements` - collection of elements identifiers that the document class contains

Please also note the `Use` attribute next to element's identifier. That way the document class states which elements are mandatory and which are optional.  


### List supported document categories [](#lsdcategories)

In the example code below, we show how to get the overview of supported document categories:

```csharp
ICatalogClient4Configs service = new CatalogClient4Configs(Settings);

IEnumerable<CategoryVm> categories = await service.GetCategories();
```

Here is the example result:

```
[
   {
      "Id": "hr-0000002-vrij002",
      "Title": "Vrij beschikbaar 2",
      "Class": "hr-dossierDienstverband",
   }, 
   {
      "Id": "hr-0000002-corrPersoonlijk",
      "Title": "Correspondentie persoonlijk",
      "Class": "hr-dossierDienstverband",
   },   
   {
      "Id": "hr-0000002-CLS",
      "Title": "Testdocumenten",
      "Class": "hr-dossierDienstverband",
   },

   ...
]
```
As we see in the response, document category has the following attributes: 
*  `Id` - category's unique identifier
*  `Title` - user friendly name
*  `Class` - identifier of the document class this category belongs to


### Get document retention plans [](#gdrp)

When adding document to Catalog, it is possible to choose for how long this document will exist. Digital catalog allows to choose from a pre-defined set of retention periods. 
List of possible retention periods can be obtained via the following code: 

```csharp
ICatalogClient4Configs service = new CatalogClient4Configs(Settings);

IEnumerable<RetentionPeriodVm> retentionPeriods = await service.GetRetentionPeriods();
```

Here is the example result:

```
[
  {
    "Code": "ONBEPERKT",
    "Description": "Onbeperkt"
  },
  {
    "Code": "INGANGSDATUM20JAAR",
    "Description": "Ingangsdatum plus 20 jaar"
  },
  {
    "Code": "INGANGSDATUMVOLGENDJAAR5JAAR",
    "Description": "5 jaar na 1 januari van het jaar volgend op de ingangsdatum"
  },
  ...
]
```

In the response: 
*  `Code` - retention period's unique identifier 
*  `Description` - user friendly description 


However to ensure that all documents of the same sort will have the same retention period, we introduce the concept of `RetentionSchedule`.  Retention schedule is, simply put, a pre-configured 
dictionary that states which retention period will be used for a specific document category. The following code example shows how to get the overview of available retention schedules:

```csharp
ICatalogClient4Configs service = new CatalogClient4Configs(Settings);

IEnumerable<RetentionScheduleVm> retentionSchedules = await service.GetRetentionSchedules();
```

Here is the example result:

```
[
  {
    "Code": "DEFAULT",
    "Description": "Standaard bewaarschema",
    "DefaultPeriod": "UITDIENST2JAAR",
    "Documents": {
      "hr-0000002-idBewijs": "UITDIENST5JAAR",
      "hr-0000002-werkvergunning": "INGANGSDATUMVOLGENDJAAR5JAAR",
      "hr-0000002-ovArbeidsvoorwaarden": "UITDIENST7JAAR",
      ...
    }
  },
  ...
]
```

Each retention schedule has the following attributes: 
*  `Code` - schedule's unique identifier
*  `Description` - user friendly description
*  `DefaultPeriod` - default retention period 
*  `Documents` - collection of `document category`/`retention period` pairs for documents types whose retention period deviates from the default

Digital catalog can be configured to have multiple retention schedules. However, the default retention schedule is always present. When adding new document to the Catalog, the identifier of the 
retention schedule can be passed as one of the arguments. If no retention schedule identifier found, the default schedule will be used. 



## Working with documents [](#wwd)

In this section we will consider the most typical operations with documents

### Adding new document [](#and)

Here is the example code that adds a new document to the Catalog

```csharp
CreateDocumentVm model = new CreateDocumentVm
{
   Category = "hr-0000002-ovPersoonlijk",
   RetentionScheduleCode = "DEFAULT",
   Elements = new Dictionary<string, string>
   {
      {"hr-bronsysteem", "home pc"},
      {"d-productCombinatie", "abc123"},
      {"d-medewerkerNummer", "123"},
      {"hr-ingangsDatum", "2019-11-12"},
      {"hr-documentOmschrijving", "loren ipsum"}
   },
   ContentType = "application/pdf",
   Content = GetDocumentBytes()
};

ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

string documentTicket = await service.CreateDocument(model);
```

In this example, the model we need to pass to the client service has the following attributes: 
* `Category` - identifier of document category (required)
* `RetentionScheduleCode` - identifier of retention schedule (optional)
* `ContentType` - MIME content type of the document 
* `Content` - binary document contetn (byte array)
* `Elements` - collection of `element identifier`/ `element value` pairs

In the example code above, adding document to Catalog will return a string variable named 'documentTicket'. The 'ticket' in the name of the varible suggests a limited validity period after 
which it will expire. So 'Document ticket' is a temporary unique identier of the document within the Catalog. Under the hood, the ticket contains embedded timestamp which gets controlled 
every time the ticket is used to access the Catalog. Introducing time limit on the document ticket is a security feature to minimize the risk of data leaks and unauthorized access. 

When the ticket has expired, in order to get access to the document, a new ticket has to be generated. Here below is an example of a document ticket:

```csharp
17000000059D000000000000010000FFFF030B53252EF9F64602639DC1596ED788E7D63AF18FB5CFA58DFFF3ED31F97FA2A261FB2E
```

It is worth mentioning that the ticket contains digital signature to avoid manipulations with expire date and is made URL 'friendly'. 


### Read document's content [](#rdc)

To read back the binary content of an already uploaded document, the following code can be used:

```csharp
ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

byte[] bytes = await service.GetDocumentContent(documentTicket);
```

The result of that code is the binary array that represetns the docoment's binary content. 


### Read document's metadata [](#rdm)

The following code example shows how to read back document's metadata:

```csharpt
ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

DocumentVm documentMetadata = await service.GetDocumentMetadata(documentTicket);
```

Example response:

```csharp
{
  "Category": "hr-0000002-ovPersoonlijk",
  "Elements": [
    {
      "Name": "hr-bronsysteem",
      "Value": "home pc"
    },
    {
      "Name": "a-documentDateModified",
      "Value": "2019-11-21T09:37:39"
    },
    {
      "Name": "a-documentAnnotated",
      "Value": false
    },
    ...
  ],
  "ContentType": "application/pdf",
  "Version": 1,
  "DateCreated": "2019-11-21T09:37:39.0000000+01:00",
  "DateLastModified": "2019-11-21T09:37:39.0000000+01:00",
  "RetentionScheduleCode": "DEFAULT"
}
```

### Create document's version [](#cdv)

In the previous example response, please pay attention to `Version` attribute which is set to `1`. As one might guess, it is possible to have multiple versions of the same 
document in the Catalog. This feature comes very handy in document approval scenarios when several people must agree on the same document. In this use case, several interations 
might be required to get the final version. Yet for audit purposes, it is important to keep all the intermediate versions. 


When we add a new document to Catalog, its current version number is automacally set to `1`. The following example shows how to upload another version of the same 
document: 

```csharp
CreateDocumentVersionVm model = new CreateDocumentVersionVm
{
   ContentType = "application/pdf",
   Content = GetUpdatedBytes()
};

ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

string documentVersionTicket = await service.CreateDocumentVersion(documentTicket, model);
```

In this example, `documentTicket` is the document ticket of one of the previous document versions. Yes, it implies that each document version will recieve its 
own document ticket. In other words, the document ticket is coupled to a specific document version. Including document version inside document ticket remarkably 
simplifies communication with Catalog since there is no longer need to pass along additional version number. Plus there is less chance that the wrong version of the document 
will be updated or removed. 

### List documents version [](#ldv)

Despite the fact each document version gets its own ticket and may look like a completely independant document, all document versions are related to the same document. Given 
ticket of an `arbitrary` document version, it is possible to get the overview of `all` available document versions: 

```csharp
ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

IEnumerable<DocumentVersionVm> documentVersions = await service.GetDocumentVersions(documentTicket);
```

Here is the example response: 

```csharp
[
  {
    "Ticket": "17000000089D00000000000001...",
    "Version": 1,
    "ContentType": "application/pdf",
    "DateCreated": "2019-11-21T10:29:06.0000000+01:00",
    "DateLastModified": "2019-11-21T10:29:06.0000000+01:00",
  },
  {
    "Ticket": "17000000089D00000000000002...",
    "Version": 2,
    "ContentType": "application/pdf",
    "DateCreated": "2019-11-21T10:29:06.0000000+01:00",
    "DateLastModified": "2019-11-21T10:29:06.0000000+01:00",
  },
  ...
]
```

Please note that the overview also includes corresponding document ticket for every document version. 


### Remove document version [](#rdv)
When a created document version is no longer needed, it is possible to remove it. 
This code example shows how to do that: 

```csharp
ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

await service.DeleteDocumentVersion(documentVersionTicket);
```


### Update document's metadata [](#udm)

Document version is the way to 'update' document content itself. It is, of course, also possible to update document's accompanying information. 
There are some restrictions though. Here is the list of what can be updated: 

* Document's retention schedule
* New elements and their values can be added to metadata
* Existing element value can be updated only if the corresponding element is not read only

In the example code below we show how to insert/update element:

```csharp
UpdateDocumentVm model = new UpdateDocumentVm
{
   Elements = new Dictionary<string, string>
   {
      {"hr-medewerkerCode", "dummy"}
   }
};

ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

await service.UpdateDocumentMetadata(documentTicket, model);
```
Please note that in the model we present only those elements that need to be inserted or updated. If the element is already present in the metadata, its value will be updated. Otherwise, 
a new element will be added to the metadata. 


### Remove document [](#rd)

Earlier we have shown how to remove a specific document version. It is also possible to remove all document versions via a single call. The code 
example below shows how to do that:

```csharp
ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

await service.DeleteDocument(documentTicket);
```

In this code example, `documentTicket` is a document ticket of an `arbitrary` document version. 

### Document events [](#de)

In this section, we will briefly discuss document events. Document event, as the name implies, is an event that can happen to a document. Catalog registers all actions and manipulations 
on documents together with the related context (e.g., name of the user who run the action, document version number, etc). Name of the events that are applied to documents within a document class can be found 
in the document class definition itself:


```csharp
[
  {
    "Id": "hr-dossierDienstverband",
    "Title": "dossierDienstverband",
    "Elements": 
    [
       ...
    ],
    "Events": 
    [
      "a-documentCreated",
      "a-documentDeleted",
      "a-documentUpdated",
      ...      
    ]
  }
]
```

The code example below shows how to get all events that have happened to a specific document:

```csharp
ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

IEnumerable<DocumentEventVm> documentEvents = await service.GetDocumentEvents(documentTicket);
```

Where result is as follows: 
```csharp
[
  {
    "Id": 70741,
    "EventName": "a-documentCreated",
    "Timestamp": "2019-11-21T13:50:36.0000000+01:00",
    "DocumentVersion": 1,
    "Actor": "webapi",
  },
  {
    "Id": 70742,
    "EventName": "a-documentCheckedInNewVersion",
    "Timestamp": "2019-11-21T13:50:36.0000000+01:00",
    "DocumentVersion": 2,
    "Actor": "webapi",
  }
]

```
Each event in the list has the following attributes:
* `Id` - event's unique id
* `EventName` - event's name
* `Timestamp` - when did event took place 
* `DocumentVersion` - to which document version it referres to
* `Actor` - name of actual user or automatic process that has triggered the event

### Document annotations [](#da)
Another small topic we would like to talk to is a `Document Annotation`. 'Document annotation' is a way to add user remarks to a specific document version. These feature
may become handy when the document should finalized by several users and provides a simple way to add editor's remarks. The remarks can also be `private`. In that case
they will only be visible to the one who created them. It is possible to add as many as you like annotations to each document version. 

Code example below shows how to add annotation:

```csharp
CreateAnnotationVm model = new CreateAnnotationVm {IsPublic = true, Text = "abc"};

ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

await service.AddDocumentAnnotation(documentTicket, model);
```

It is possible to list all document annotations: 
```csharp
ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

IEnumerable<AnnotationVm> documentAnnotations = await service.GetDocumentAnnotations(documentTicket);
```
Where result is: 
```csharp
[
  {
    "Ticket": "020017000000289D00000000000001...",
    "Author": {
      ...
    },
    "DateCreated": "2019-11-21T14:09:43.0000000+01:00",
    "DateModified": "2019-11-21T14:09:43.0000000+01:00",
    "Text": "This is annotation 2",
  },
  {
    "Ticket": "010017000000289D0000000000000...",
    "Author": {
        ...
    },
    "DateCreated": "2019-11-21T14:09:43.0000000+01:00",
    "DateModified": "2019-11-21T14:09:43.0000000+01:00",
    "Text": "This is annotation 1",
  }
]
```
Here: 
* `Ticket` - each annotation gets its own ticket. That way it can be addressed directly
* `Author`- details of user or process who created or updated the annotation 
* `DateCreated` - date when annotation is added
* `DateModified` - date when annotaiton is modified
* `Text` - text of the annotation 

Since each annotation will get its own ticket, it possible to access it directly. This comes handy when someone would like to update it (both public flag and annotation 
text can be upated): 
```
UpdateAnnotationVm model = new UpdateAnnotationVm {IsPublic = true, Text = "newAbc2"};

ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

await service.UpdateDocumentAnnotation(documentTicket, annotationTicket, model);
```

And of course, given annotation ticket, we can delete it:
```
ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

await service.DeleteDocumentAnnotation(documentTicket, annotationTicket);
```

Also be aware that when creating a new document version it is possible to 'copy' document annotations of the previous version to that new version. 


## Document queries [](#documentqueries)
When documents have been added to the Catalog, it is of course, important to be able to find them back. In this section we will discuss how to search for documents. 
The Catalog allows to find documents by one or several element values. Searching in binary content itself is not supported. 

### Find documents by text [](#fdbt)
In the examples below, we show how to find documents whose metadata (at least one of element values) contains a certain text fragment. We also need to specify
in which document class the Catalog need to look for:

```csharp
ICatalogClient4DocumentQueries service = new CatalogClient4DocumentQueries(Settings);

string queryResultTicket = await service.FindDocumentsWithinClass(documentClassId, searchText);
```
Or to narrow down search results to a specific document category:
```csharp
ICatalogClient4DocumentQueries service = new CatalogClient4DocumentQueries(Settings);

string queryResultTicket = await service.FindDocumentsWithinCategory(documentCategoryId, searchText);
```
This will return a string named `queryResultTicket` with example value:

```csharp
MzY1MzEyNjgtZWE1NC00Yzk4LTgzM2MtZmMwZGE0Zjc2MGQ
```

As the name implies, this string is also a ticket to access query result. Similar to document tickets, it has a life span after which it will expire. Under the hood, 
this ticket is the key to the cache where the query result will be temporarily stored. When this ticket expires, a new should be generated by running the same 
quer once again. Please note that if search text is an empty string then no filtering is applied and all documents returned. 


### Get query result metadata [](#gqrm)

Given the query result ticket, one can read some metainformation about the extracted query result: 

```csharp
ICatalogClient4DocumentQueries service = new CatalogClient4DocumentQueries(Settings);

DocumentSetMetaDataVm queryResultMetadata = await service.GetResultsetMetadata(queryResultTicket);
```

With example result:

```charp
{
  "Columns": [
    "hr-bronsysteem",
    "d-productCombinatie",
    "d-klantnummer",
    "hr-hrIdentifier",
    ...
  ],
  "SortOrder": [],
  "TotalNumberRows": 18
}
```

The metainformation contains the following attributes: 
* `Columns` - contains the list of element names returned by the query. 
* `SortOrder`- is collection of sort expressions in the format of `element name asc/desc`. It is initially empty, however sorting can be applied 
later after the query result is already created (more on this later on).
* `TotalNumberRows` - total number rows found in the query. Please be aware that, for performance reasons, the Catalog will limit the maximum number of returned 
rows to 1000 (subject to configuration). 

Please be aware by searching for documents with text frament, it is not possible to specify which elements we want to see in the 
query result. For that type of queries, all elements registered in the corresponding document class will be returned. 


### Get all rows [](#gar)
To get all rows in the query result, the following code can be used:

```csharp
ICatalogClient4EntityQueries service = new CatalogClient4EntityQueries(Settings);

IEnumerable<EntityRowVm> allRows = await service.GetAllRows(queryResultTicket);
```

This will deliver the following collection: 

```csharp
[
  {
    "Ticket": "170000000200000000000000010000FF...",
    "ClassName": "hr-dossierDienstverband",
    "DocumentName": "hr-0000002-ovPersoonlijk",
    "ContentType": "image/jpeg",
    "Values": [
      "PORTAL",
      "BO4GEM",
      "0000002",
      ...
    ]
  },
  {
    "Ticket": "1E0000002100000000000000010000FFF...",
    "ClassName": "hr-dossierDienstverband",
    "DocumentName": "hr-0000002-werkvergunning",
    "ContentType": "application/msword",
    "Values": [
      "PORTAL",
      "BO4GEM",
      "0000002",
      ...
    ]
  },
]
```
Each row in that collection corresponds to a separate document where:
* `Ticket` - document ticket
* `ClassName` - document class identifier
* `DocumentName` - document category identifier 
* `ContentType` - content type of the document (MIME)
* `Values` - collection of element values.

Please note that row contains only element values and not element names. This is to ensure that the amount of data to send over the wire remains small. The order in which the 
values are listed is the very same order in which elements names appear in the query result metadata. 

### Get specific row [](#gsrow)
The following example code shows how to access a specific row in the query result by index: 

```csharp
ICatalogClient4DocumentQueries service = new CatalogClient4DocumentQueries(Settings);

DocumentRowVm row = await service.GetSpecificRow(queryResultTicket, rowIndex);
```

### Get specific rows [](#gsrows)
It is also possible to 'page' query result:

```csharp
ICatalogClient4DocumentQueries service = new CatalogClient4DocumentQueries(Settings);

IEnumerable<DocumentRowVm> subRows = await service.GetSpecificRows(queryResultTicket, numberRowsToSkip, numberRowsToReturn);
```

### Changing sort order [](#cso)
The following example, shows how to sort query result:

```csharp
ICatalogClient4DocumentQueries service = new CatalogClient4DocumentQueries(Settings);

SortOrderVm model = new SortOrderVm {OrderBy = new[] {"d-klantnummer desc", "d-productCombinatie asc"}};

await service.ChangeSortOder(queryResultTicket, model);
```

This command will update the query result in the cache. To get sorted rows, one needs to read them again. 

### Using custom query [](#ucq)
The Catalog allows to create and run own custom queries which allow the following: 

* Select which elements to return in the query result
* Be able to filter on specific elements
* Be able to provide sorting expressions in the begin to avoid futher calls 
* And possibility to limit number of rows returned to avoid sending to much data

Here is an example of how to run a custom query: 

```csharp
CatalogQueryVm query = new CatalogQueryVm
{
   Query = new CatalogQueryContentVm
   {
      Select = new[] {"d-klantnummer", "d-productCombinatie", "a-documentDateCreated"},
      Where = new Dictionary<string, string> {{ "d-productCombinatie", "BO4GEM" } },
      Top = 30,
      OrderBy = new[] {"a-documentDateCreated asc"}
   }
};

ICatalogClient4DocumentQueries service = new CatalogClient4DocumentQueries(Settings);

string queryResultTicket = await service.FindDocuments(query);
```

Please note that in the custom query `where`, `top`, and `orderBy` are optional. The custom query will return an already familiar query 
result ticket that can later be used in the methods we discussed above. 


## Entities [](#entities)

In the previous chapters we have discussed documents and typical operations we can do with them. The metadata that is attached to the document provides all sorts of information about the document file. However, 
in some cases, that information might not be complete. Imagine that we need to add a shipping contract. When
that document is created only the shipping number is known. The actual shipping date will be available only later. That date will be generated by one of the customers's own 
applications and will only be accessible via HTTP API call. To add 'external' data sources to the Catalog, the concept of `Entity` is introduced. `Entity` is a logical table that
abstracts the actual data source. 

A document in the Catalog can be 'linked' to an entity. Simply put, a record in 'documents' table will have a matching 'row' in 'entity' table. The match is done by using shared 
primary key. That is a combination of elements present in both tables that uniquely identify each row. Futhermore, a document can be linke to more than one entity. In that case, 
a single 'document row' may have several matching exteral rows each residing in a separate table. 



### List availabe entities [](#listentities)
The following code shows how to get the overview of available entites: 

```csharp
ICatalogClient4Configs service = new CatalogClient4Configs(Settings);

 IEnumerable<EntityVm> entities = await service.GetEntities();
```
With the response:

```csharp
[
   {
     "Id": "hr-medewerker",
     "Title": "medewerker",
     "Elements": [
       {
         "Element": "d-klantnummer",
         "Use": "Mandatory"
       },
      ...
     ],
     "Identifiers": [
       {
         "Elements": [
           "d-klantnummer",
           "d-productCombinatie",
           "d-medewerkerNummer"
         ]
       }
     ]
   },
   ...
]
```

Each entity in the collection has the following attributes: 
* `Id` - entity's unique identifier
* `Title` - entity's user friendly name
* `Elements` - element identifers that the entity consists of (required elements are marked with `Mandatory` flag)
* `Identifiers` - here we list entity identifiers. Each identifier represents an element or collection of elemetns that uniquely identifiers 
every 'row' in entity (similar to primary key in conventional databases)

Some important remarks here. Entities are not bound to document classes. That implies that an entity can contain elements that 
are not present in any of the known document classes. However, to be able to match entities and documents it is important that 
the elements names in an entity identifier are also known in document classes. Next, each document class can be 'linked' to one 
or several entities. In the definition of a document class one can see `Entities` property:

```csharp
[
  {
    "Id": "hr-dossierDienstverband",
    "Title": "dossierDienstverband",
    "Elements": [
      ...
    ],
    "Entities": [
      {
        "Entity": "hr-medewerker",
        "Use": "Mandatory"
      },
      {
        "Entity": "hr-dienstverband",
        "Use": "Optional"
      }
    ]
  }
]
```

This property indicates to which entities the documents that belong to that class can be linked to. Note that one entity here is marked as mandatory, and the other as optional. 
The mandary here implies that for each document in that class there will always be a row in the 'entity' table. 



### Searching for documents using entity [](#sfdue)
In the previous chapter we have described how to search for documetns using document's own metadata. The 
catalog also allows to search for documents using entities. In that case, the search will be a more complex two step process: 
* we will search in entities's metadata
* when entitiess located, linked documetns will be extracted

For the client side however, searching using entities is very similar to document queries we saw before. In the example below, 
we show how to search for documents linked to entities whose metadata contains provided text fragment:

```csharp
ICatalogClient4EntityQueries service = new CatalogClient4EntityQueries(Settings);

string queryResultTicket = await service.FindEntities(entityId, searchText);
```

The following example shows how to get query result's metadata:
```
ICatalogClient4EntityQueries service = new CatalogClient4EntityQueries(Settings);

EntitySetMetaDataVm queryResultMetadata = await service.GetQueryResultMetadata(queryResultTicket);
 ```
 With the example result is as follows:
 ```csharp
 {
  "Columns": [
    "d-klantnummer",
    "d-productCombinatie",
    "d-medewerkerNummer",
      ...
  ],
  "SortOrder": [],
  "TotalNumberRows": 3
}
```
To get all rows from the query result:
 ```csharp
ICatalogClient4EntityQueries service = new CatalogClient4EntityQueries(Settings);

IEnumerable<EntityRowVm> rows = await service.GetAllRows(queryResultTicket);
```

To get specific row from the query result: 
 ```csharp
ICatalogClient4EntityQueries service = new CatalogClient4EntityQueries(Settings);

EntityRowVm row = await service.GetSpecificRow(queryResultTicket, rowIndex);
```

To get specific rows from the query result: 
 ```csharp
ICatalogClient4EntityQueries service = new CatalogClient4EntityQueries(Settings);

IEnumerable<EntityRowVm> rows = await service.GetSpecificRows(queryResultTicket, numberRowsToSkip, numberRowsToTake);
```

Change query result sort order:
 ```csharp
ICatalogClient4EntityQueries service = new CatalogClient4EntityQueries(Settings);

SortOrderVm sortOrderVm = new SortOrderVm {OrderBy = new[] {"d-klantnummer desc"}};

await service.ChangeSortOder(queryResultTicket, sortOrderVm);
```

Perform custom query:
 ```csharp
string entityId = "hr-medewerker";

CatalogQueryVm query = new CatalogQueryVm
{
   Query = new CatalogQueryContentVm
   {
      Select = new[] {"d-klantnummer"},
      Where = new Dictionary<string, string> {{"d-productCombinatie", "BO4GEM"}},
      OrderBy = new[] {"d-klantnummer asc"},
      Top = 25
   }
};

ICatalogClient4EntityQueries service = new CatalogClient4EntityQueries(Settings);

string queryResultTicket = await service.FindEntities(entityId, query);
```
Please note that in that custom queries only those elements can be used that are present in the entity's definition. 



## Views [](#views)

In the previous sections we showed how to search for documents (with entities and without). There is also another way to find documents which can be very useful when 
building UI on top the Catalog. Imagine we need to build UI to display all documents in the archive. We have a limited space on the screen and we want to use 'tabs' and content 
area where query result will be shown. On each tab we want to display only documents that are logically related (say HR documents). Still the number of HR documents can be quite large 
so we want to add the possibility to narrow down search results. For that we introduce a tree-like side menu on the left side of the screen. Choosing a node in that menu will control how 
much data will be shown in the content area. Choosing the lower node implies more specific query and thus less data on the screen. Choosing the higher node 'aggregates' query results 
from underlying nodes so more data is displayed. Precisely for that situation the `View` is introduced in the Catalog. The view is our imaginary 'tab'. Simply put, it is a named group of documents. 


### List available views [](#lav)
The following example shows how to get what views are available:

```csharp
ICatalogClient4Views service = new CatalogClient4Views(Settings);

IEnumerable<SchemaViewVm> views = await service.GetAllViews();
```

This returns the following collection:

```csharp
[
  {
    "Id": "default",
    "Root": 
    {
      "Id": "V001",
      "Description": "Personeelsdossier",
      "Children": 
         [
           {
             "Id": "V011",
             "Description": "Prullenbak",
             "Children": 
                [
                ...
                ]
           },
           ...
         ]
    }
  },
   ...
]
```

As seen from the result, each view has the following attributes: 
* `Id`- unique identifier of the view
* `Root`- points to the top of the tree like structure that corresponds to the tree menu from our imaginary UI 

Each node in that menu has the following attributes: 
*  `Id`- name of the node. Please note that it is unique only within parent view. 
* `Description` - user friendly display name 
* `Children` -  collection of child nodes


### Find documents using views [](#fdbvn)
We will refer to each node in the tree menu as simply `view node`. The Catalog allows to assign a collection of document categories to each of the view nodes. This allows 
to utilize already available search mechanism based on document categories. The following code example shows how to get the overview of document categories 
attached to a specific node:

```csharp
ICatalogClient4Views service = new CatalogClient4Views(Settings);

IEnumerable<CategoryVm> categories = await service.GetCategories(viewId, viewNodeId);
```

The resulting collection is the aggregate of document categories assigned to its children plus document categories attached to the node itself. 
The following code example shows how to search for documents 'under' a certain view node:

```csharp
ICatalogClient4Views service = new CatalogClient4Views(Settings);

string queryResultTicket = await service.FindDocuments(viewId, viewNodeId, searchText);
```

The result of that query is familiar query result ticket that can be used in the same way as the ticket obtained from the document query. It is also worth mentioning that
when searching for documents via view nodes we search in multiple document categories with the single call. 
