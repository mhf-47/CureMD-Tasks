﻿using System;
using System.Data;
using System.Data.SqlClient;

string ConnectionString = "Server=DESKTOP-GM9QCQ5\\SQLEXPRESS; Database=MHFNEW; Trusted_Connection=TRUE;";
using (SqlConnection connection = new SqlConnection(ConnectionString))
{
    //Execute stored procedure to List all students
    using (SqlCommand command = new SqlCommand("ListAllStudents", connection))
    {
        command.CommandType = CommandType.StoredProcedure;

        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine("StudentID: " + reader["StudentID"] + ",FirstName: " + reader["FirstName"] + ",LastName: " + reader["LastName"] + ",Age: " + reader["Age"] + ",CourseID: " + reader["CourseID"]);
        }
        connection.Close();
    }

    Console.WriteLine("--------------------------------------------------------");

    //Execute stored procedure to add a new student
    using (SqlCommand command = new SqlCommand("AddStudent", connection))
    {
        command.CommandType = CommandType.StoredProcedure;
        
        command.Parameters.AddWithValue("@newFirstName", "Hamza");
        command.Parameters.AddWithValue("@newLastName", "Qadir");
        command.Parameters.AddWithValue("@newAge", 45);
        command.Parameters.AddWithValue("@newCourseID", 105);

        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    //Execute stored procedure to List all students
    using (SqlCommand command = new SqlCommand("ListAllStudents", connection))
    {
        command.CommandType = CommandType.StoredProcedure;

        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine("StudentID: " + reader["StudentID"] + ",FirstName: " + reader["FirstName"] + ",LastName: " + reader["LastName"] + ",Age: " + reader["Age"] + ",CourseID: " + reader["CourseID"]);
        }
        connection.Close();
    }

    Console.WriteLine("--------------------------------------------------------");

    //Execute stored procedure to Update a student's Age
    using (SqlCommand command = new SqlCommand("UpdateStudentAge", connection))
    {
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@ID", 3);
        command.Parameters.AddWithValue("@newAge", 34);
        
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    //Execute stored procedure to List all students
    using (SqlCommand command = new SqlCommand("ListAllStudents", connection))
    {
        command.CommandType = CommandType.StoredProcedure;

        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine("StudentID: " + reader["StudentID"] + ",FirstName: " + reader["FirstName"] + ",LastName: " + reader["LastName"] + ",Age: " + reader["Age"] + ",CourseID: " + reader["CourseID"]);
        }
        connection.Close();
    }

    Console.WriteLine("--------------------------------------------------------");

    //Execute stored procedure to Update a student's Age
    using (SqlCommand command = new SqlCommand("DeleteStudent", connection))
    {
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@ID", 2);
        
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    //Execute stored procedure to List all students
    using (SqlCommand command = new SqlCommand("ListAllStudents", connection))
    {
        command.CommandType = CommandType.StoredProcedure;

        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine("StudentID: " + reader["StudentID"] + ",FirstName: " + reader["FirstName"] + ",LastName: " + reader["LastName"] + ",Age: " + reader["Age"] + ",CourseID: " + reader["CourseID"]);
        }
        connection.Close();
    }

}