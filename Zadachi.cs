using System;
namespace Zadachi
{
    public class Zadacha
    {
        public Guid Id {get;set;}        
        public string Name {get;set;}     
        public string Description {get;set;}
        public string Tag {get;set;}
        public DateTime Date {get; set;}
        /* Для записи в текстовый файл .txt
        public string kString()
            {
                return $"{Id} \n{Name}  \n{Description} \n{Tag} \n{Date} \n";
            }
            */
    } 

}