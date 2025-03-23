using namespace QPI;

struct HM252
{
};

struct HM25 : public ContractBase
{
public:
    struct SetMilestone_input{};
    struct SetMilestone_output{};

    struct GetMilestone_input{};
    struct GetMilestone_output
    {
        uint64 lastMilestone;
    };
    
private:
    uint64 lastMilestone;

    PUBLIC_PROCEDURE(SetMilestone)
        state.lastMilestone++;
   _

    PUBLIC_FUNCTION(GetMilestone)
        output.lastMilestone = state.lastMilestone;
    _

    REGISTER_USER_FUNCTIONS_AND_PROCEDURES

        REGISTER_USER_PROCEDURE(SetMilestone, 1);

        REGISTER_USER_FUNCTION(GetMilestone, 1);
    _

    INITIALIZE
        state.lastMilestone = 0;
    _
};
