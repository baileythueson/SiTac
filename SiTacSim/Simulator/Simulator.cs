namespace SiTacSim.Simulator;

public class Simulator
{
    public double t { get; private set; }
    public double dt { get; private set; }
    
    public Simulator(double initialTime, double timeStep)
    {
        t = initialTime;
        dt = timeStep;
    }

    public bool ShouldQuit()
    {
        return false;
    }
    
    public void Step()
    {
        t += dt;
    }

    public async Task Run()
    {
        double t = 0.0;
        double dt = 0.1;

        double currentTime = DateTime.Now.Ticks;
        double accumulator = 0.0;

        
        
        while (!ShouldQuit())
        {
            double newTime = DateTime.Now.Ticks;
            double frametime = newTime - currentTime;
            
            if (frametime > 0.25) accumulator += 0.25;
            
            currentTime = newTime;
            accumulator += frametime;
            
            while (accumulator >= dt)
            {
                t += dt;
                accumulator -= dt;
            }
            
            double alpha = accumulator / dt;
            
        }
    }
}