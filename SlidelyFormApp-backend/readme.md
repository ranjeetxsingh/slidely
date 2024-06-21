# Slidely TypeScript Server


## Prerequisites

- [Node.js](https://nodejs.org/en/download/) (v14 or later)
- [npm](https://www.npmjs.com/get-npm) (Node Package Manager)

## Getting Started
Follow these steps to set up and run the application on your local machine:

### Clone the repository
```bash
git clone https://github.com/ranjeetxsingh/slidely.git
cd slidely/SlidelyFormApp-backend
npm install
npm run build
npm start
```

The application will be running at 
```bash
http://localhost:3000

## API Endpoints

### Ping the server
##### URL:  
```bash 
  http://localhost:3000/ping
```
##### Method:
*GET*
##### Description:
*Check if the server is running.*
##### Response:
```bash
{
  "success":true
}
```

### Create A New Submission
##### URL: 
```bash 
  http://localhost:3000/submit
```
##### Method:
*POST*
##### Description:
Create a new submission from the form.
##### Request:
```bash
{
  "name": "string",
  "email": "string",
  "phone": "string",
  "github_link": "string",
  "stopwatch_time": number
}
```
##### Response:
- *201*:*Submission created successfully*
- *400*:*Missing required fields*
- *500*:*Internal Server Error*


### Read The Submitted Form
##### URL:
```bash 
  http://localhost:3000/read?index={index}
```
##### Method:
*GET*
##### Description:
Retrieve a submission by its index.
###### Query Parameters: *index* (number) : The index of the submission to retrieve.
##### Response:
```bash
{
  "name": "string",
  "email": "string",
  "phone": "string",
  "github_link": "string",
  "stopwatch_time": number
}
```
