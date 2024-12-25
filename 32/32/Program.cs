using System;
using System.Collections.Generic;
using System.Linq;

class ExamSchedule
{
    public DateTime ExamDateTime { get; set; }
    public string Subject { get; set; }
    public string TeacherFullName { get; set; }
    public string Group { get; set; }
    public string AuditoriumNumber { get; set; }

    // Конструктор для удобства создания объектов
    public ExamSchedule(DateTime examDateTime, string subject, string teacherFullName, string group, string auditoriumNumber)
    {
        ExamDateTime = examDateTime;
        Subject = subject;
        TeacherFullName = teacherFullName;
        Group = group;
        AuditoriumNumber = auditoriumNumber;
    }

    // Метод для отображения информации о расписании
    public override string ToString()
    {
        return $"{ExamDateTime,-20}{Subject,-15}{TeacherFullName,-25}{Group,-10}{AuditoriumNumber,-10}";
    }
}

class Program
{
    static void Main()
    {
        // Создание списка расписания экзаменов
        List<ExamSchedule> examSchedules = new List<ExamSchedule>
        {
            new ExamSchedule(new DateTime(2024, 6, 15, 9, 0, 0), "Математика", "Иванов Иван Иванович", "Группа A", "101"),
            new ExamSchedule(new DateTime(2024, 6, 16, 10, 0, 0), "Физика", "Петрова Мария Александровна", "Группа B", "102"),
            new ExamSchedule(new DateTime(2024, 6, 14, 8, 0, 0), "Химия", "Сидоров Александр Викторович", "Группа A", "103"),
            new ExamSchedule(new DateTime(2024, 6, 17, 11, 0, 0), "Биология", "Федорова Ольга Валерьевна", "Группа C", "104"),
            new ExamSchedule(new DateTime(2024, 6, 18, 14, 0, 0), "История", "Кузнецов Сергей Андреевич", "Группа B", "105")
        };

        // Вывод информации обо всех расписаниях
        Console.WriteLine("Расписание экзаменов:");
        Console.WriteLine($"{"Дата и время",-20}{"Предмет",-15}{"Преподаватель",-25}{"Группа",-10}{"Аудитория",-10}");
        foreach (var examSchedule in examSchedules)
        {
            Console.WriteLine(examSchedule);
        }

        // Сортировка по ФИО преподавателя
        var sortedByTeacher = examSchedules.OrderBy(e => e.TeacherFullName).ToList();
        Console.WriteLine("\nОтсортировано по ФИО преподавателя:");
        Console.WriteLine($"{"Дата и время",-20}{"Предмет",-15}{"Преподаватель",-25}{"Группа",-10}{"Аудитория",-10}");
        foreach (var examSchedule in sortedByTeacher)
        {
            Console.WriteLine(examSchedule);
        }

        // Сортировка по группе
        var sortedByGroup = examSchedules.OrderBy(e => e.Group).ToList();
        Console.WriteLine("\nОтсортировано по группе:");
        Console.WriteLine($"{"Дата и время",-20}{"Предмет",-15}{"Преподаватель",-25}{"Группа",-10}{"Аудитория",-10}");
        foreach (var examSchedule in sortedByGroup)
        {
            Console.WriteLine(examSchedule);
        }

        // Сортировка по номеру аудитории
        var sortedByAuditorium = examSchedules.OrderBy(e => e.AuditoriumNumber).ToList();
        Console.WriteLine("\nОтсортировано по номеру аудитории:");
        Console.WriteLine($"{"Дата и время",-20}{"Предмет",-15}{"Преподаватель",-25}{"Группа",-10}{"Аудитория",-10}");
        foreach (var examSchedule in sortedByAuditorium)
        {
            Console.WriteLine(examSchedule);
        }
    }
}
