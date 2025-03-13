# Task Tracker CLI

Task Tracker CLI is a simple command-line application that allows you to add, update, mark, and delete tasks in a JSON file. The application also lets you view a list of tasks based on their status.

Sample solution for the [task-tracker](https://roadmap.sh/projects/task-tracker) project from [roadmap.sh](https://roadmap.sh/).

## Features



-  **Add task:** Add a new task with a description and a default status of "to-do".

-  **List tasks:** View a list of tasks based on their status ("todo", "in-progress", "done") or all tasks.

-  **Update task:** Update the description of an existing task based on its ID.

-  **Mark Task Status:** Change the status of a task to "in-progress" or "done" based on its ID.

-  **Delete Task:** Remove an existing task based on its ID.

## Requirements
- .NET 9 SDK

## Installation

1. **Clone repository**:
   ```bash
   git clone https://github.com/TonySauceda/TaskTrackerCLI.git
   cd TaskTrackerCLI
   ```
2. **Packs the code into a NuGet package**:
   ```bash
   dotnet pack
   ```
3. **Install the NuGet package**:
   ```bash
   dotnet tool install --global --add-source .\nupkg TaskTrackerCLI
   ```

## Usage
### Add Task
  ```bash
  task-cli add "Enter task description"
  ```

### Update Task
  ```bash
  task-cli update Id "Enter task description"
  ```

### Delete Task
  ```bash
  task-cli delete Id
  ```

### List All Tasks
  ```bash
  task-cli list
  ```

### List Tasks by Status
  ```bash
  task-cli list todo
  task-cli list in-progress
  task-cli list done
  ```

### Mark Task as In Progress
  ```bash
  task-cli mark-in-progress Id
  ```

### Mark Task as Done
  ```bash
  task-cli mark-done Id
  ```

### Print All Commands
  ```bash
  task-cli help
  ```
