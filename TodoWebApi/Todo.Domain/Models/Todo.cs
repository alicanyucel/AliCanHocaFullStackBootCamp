

namespace Todo.Domain.Models;
// sealded yaparsak todo classı başka bir classa miras veremez

// Guid örneği 5fff2d0b-ec50-4b48-bd9a-6380b3ad807f
public  class Todo
{// normalde id değerleri int alır fakat best practise olraktan guid tanımlanmalı
    public Guid Id { get; set; }
    public string Work { get; set; } = default!; // 
    public DateOnly DeadLine { get; set; }
    public bool IsCompleted { get; set; }
    //veri tipinin yanında ? işarati varsa boş bırakılabilir anlamında   
    public string? Note { get; set; }
}
