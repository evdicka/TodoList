## TodoList Application

- A simple console application for managing tasks (To-Do List) in C#.

## Features
- Show all tasks: Displays all saved todos with their details
- Create new task: Creates a new task with title and description
- Mark task as completed: Marks an existing task as done
- Delete task: Removes a task from the list

## Technical Details
- The application consists of the following components:
- TodoItem: Represents a single task with ID, title, description, status, and creation date
- ITodoListLogic: Interface for business logic
- TodoListLogic: Implementation of the logic with CSV file as storage
- Menue: User interface for interaction

## Data Storage
- The todos are stored in the file TodoList.csv in the format ID;Title;Description;Completed;CreationDate.

## Usage
- Start the application and select an option from the menu (1-5). Follow the on-screen instructions.
