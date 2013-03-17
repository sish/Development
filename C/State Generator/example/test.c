/*===========================================================================*/
// STATE EVENT MACHINE EXAMPLE
#include "stdio.h"
#define EVENT    3
#define STATE    3
void Neutral (void);
void Forward (void);
void Reverse (void);
void Not_Valid (void);
enum { NEUTRAL, REVERSE, FORWARD};
enum { NEUTRAL_BTN, REVERSE_BTN, FORWARD_BTN};
char currentState = NEUTRAL;


/*===========================================================================*/ 
void (* State_Event_Matrix[EVENT][STATE]) () =
{
    {   // Event Neutral_btn
        Not_Valid,      // State NEUTRAL
        Neutral,        // State FORWARD
        Neutral,        // State REVERSE          
    },
    {   // Event Reverse_btn
        Reverse,        // State NEUTRAL       
        Not_Valid,      // State FORWARD
        Not_Valid,      // State REVERSE            
    },
    {   // Event Forward_btn
        Forward,        // State NEUTRAL       
        Not_Valid,      // State FORWARD
        Not_Valid,      // State REVERSE            
    }
};
 
/*===========================================================================*/
void Not_Valid (void)
{
    printf("\nNot valid, state unchanged!!!\n");
}
 
/*===========================================================================*/
void Neutral(void)
{
    printf("\nState changed to NEUTRAL!!!\n");
    currentState = NEUTRAL;
}
 
/*===========================================================================*/
void Forward(void)
{
    printf("\nState changed to FORWARD!!!\n");
    currentState = FORWARD;
}
 
/*===========================================================================*/
void Reverse(void)
{
    printf("\nState changed to REVERSE!!!\n");
    currentState = REVERSE;
}
 
/*===========================================================================*/
int main (int argc, char *argv[])
{
    int quit = 0, c;
    printf("\n-----------------------------------------\n");
    printf("- State Event Machine Test              -\n");
    printf("- 'n' --> Change state to NEUTRAL       -\n");
    printf("- 'f' --> Change state to FORWARD       -\n");
    printf("- 'r' --> Change state to REVERSE       -\n");
    printf("- 'q' --> Quit                          -\n");
    printf("-----------------------------------------\n");
    // Always start the machine in Neutral state
    Neutral();
    while ((c = getchar()) != 'q')
    {
       
        switch(c)
        {
        case 'n':
            State_Event_Matrix[NEUTRAL_BTN][currentState]();
            break;
        case 'f':
            State_Event_Matrix[FORWARD_BTN][currentState]();
            break;
        case 'r':
            State_Event_Matrix[REVERSE_BTN][currentState]();
            break;
        }
    }
    printf("\n\nThe State Event Machine is stoped by user!!!!\n\n");
}
/*===================== T h e  e n d ========================================*/ 
