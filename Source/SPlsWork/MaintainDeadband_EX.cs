using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace CrestronModule_MAINTAINDEADBAND_EX
{
    public class CrestronModuleClass_MAINTAINDEADBAND_EX : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput DUALAUTOMODE;
        Crestron.Logos.SplusObjects.DigitalInput HEATUP;
        Crestron.Logos.SplusObjects.DigitalInput COOLDOWN;
        Crestron.Logos.SplusObjects.DigitalInput RUN;
        Crestron.Logos.SplusObjects.AnalogInput DEADBAND;
        Crestron.Logos.SplusObjects.AnalogInput AUTOHEATSP_IN;
        Crestron.Logos.SplusObjects.AnalogInput AUTOCOOLSP_IN;
        Crestron.Logos.SplusObjects.AnalogInput COOLMAX;
        Crestron.Logos.SplusObjects.AnalogInput HEATMIN;
        Crestron.Logos.SplusObjects.AnalogOutput AUTOHEATSP;
        Crestron.Logos.SplusObjects.AnalogOutput AUTOCOOLSP;
        private void CHECKSETPOINTS (  SplusExecutionContext __context__ ) 
            { 
            ushort DIFFERENCE = 0;
            ushort ADJUSTED = 0;
            
            
            __context__.SourceCodeLine = 32;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( _SplusNVRAM.G_SEMAPHORE ) || Functions.TestForTrue ( Functions.BoolToInt (AUTOHEATSP_IN  .UshortValue == 0) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (AUTOCOOLSP_IN  .UshortValue == 0) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 33;
                return ; 
                }
            
            __context__.SourceCodeLine = 34;
            _SplusNVRAM.G_SEMAPHORE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 50;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (AUTOCOOLSP_IN  .UshortValue - AUTOHEATSP_IN  .UshortValue) < DEADBAND  .UshortValue ))  ) ) 
                { 
                __context__.SourceCodeLine = 52;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.LASTCHANGED == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 54;
                    ADJUSTED = (ushort) ( (AUTOHEATSP  .Value + DEADBAND  .UshortValue) ) ; 
                    __context__.SourceCodeLine = 56;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ADJUSTED <= COOLMAX  .UshortValue ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 58;
                        AUTOCOOLSP  .Value = (ushort) ( ADJUSTED ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 61;
                        AUTOHEATSP  .Value = (ushort) ( (COOLMAX  .UshortValue - DEADBAND  .UshortValue) ) ; 
                        }
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 66;
                    ADJUSTED = (ushort) ( (AUTOCOOLSP  .Value - DEADBAND  .UshortValue) ) ; 
                    __context__.SourceCodeLine = 68;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ADJUSTED >= HEATMIN  .UshortValue ))  ) ) 
                        {
                        __context__.SourceCodeLine = 69;
                        AUTOHEATSP  .Value = (ushort) ( ADJUSTED ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 72;
                        AUTOCOOLSP  .Value = (ushort) ( (HEATMIN  .UshortValue + DEADBAND  .UshortValue) ) ; 
                        }
                    
                    } 
                
                } 
            
            __context__.SourceCodeLine = 75;
            _SplusNVRAM.G_SEMAPHORE = (ushort) ( 0 ) ; 
            
            }
            
        object AUTOHEATSP_IN_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 81;
                if ( Functions.TestForTrue  ( ( DUALAUTOMODE  .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 83;
                    _SplusNVRAM.LASTCHANGED = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 84;
                    CHECKSETPOINTS (  __context__  ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object AUTOCOOLSP_IN_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 91;
            if ( Functions.TestForTrue  ( ( DUALAUTOMODE  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 93;
                _SplusNVRAM.LASTCHANGED = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 94;
                CHECKSETPOINTS (  __context__  ) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object DEADBAND_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 103;
        CHECKSETPOINTS (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 109;
        _SplusNVRAM.G_SEMAPHORE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 110;
        _SplusNVRAM.LASTCHANGED = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    DUALAUTOMODE = new Crestron.Logos.SplusObjects.DigitalInput( DUALAUTOMODE__DigitalInput__, this );
    m_DigitalInputList.Add( DUALAUTOMODE__DigitalInput__, DUALAUTOMODE );
    
    HEATUP = new Crestron.Logos.SplusObjects.DigitalInput( HEATUP__DigitalInput__, this );
    m_DigitalInputList.Add( HEATUP__DigitalInput__, HEATUP );
    
    COOLDOWN = new Crestron.Logos.SplusObjects.DigitalInput( COOLDOWN__DigitalInput__, this );
    m_DigitalInputList.Add( COOLDOWN__DigitalInput__, COOLDOWN );
    
    RUN = new Crestron.Logos.SplusObjects.DigitalInput( RUN__DigitalInput__, this );
    m_DigitalInputList.Add( RUN__DigitalInput__, RUN );
    
    DEADBAND = new Crestron.Logos.SplusObjects.AnalogInput( DEADBAND__AnalogSerialInput__, this );
    m_AnalogInputList.Add( DEADBAND__AnalogSerialInput__, DEADBAND );
    
    AUTOHEATSP_IN = new Crestron.Logos.SplusObjects.AnalogInput( AUTOHEATSP_IN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( AUTOHEATSP_IN__AnalogSerialInput__, AUTOHEATSP_IN );
    
    AUTOCOOLSP_IN = new Crestron.Logos.SplusObjects.AnalogInput( AUTOCOOLSP_IN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( AUTOCOOLSP_IN__AnalogSerialInput__, AUTOCOOLSP_IN );
    
    COOLMAX = new Crestron.Logos.SplusObjects.AnalogInput( COOLMAX__AnalogSerialInput__, this );
    m_AnalogInputList.Add( COOLMAX__AnalogSerialInput__, COOLMAX );
    
    HEATMIN = new Crestron.Logos.SplusObjects.AnalogInput( HEATMIN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( HEATMIN__AnalogSerialInput__, HEATMIN );
    
    AUTOHEATSP = new Crestron.Logos.SplusObjects.AnalogOutput( AUTOHEATSP__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( AUTOHEATSP__AnalogSerialOutput__, AUTOHEATSP );
    
    AUTOCOOLSP = new Crestron.Logos.SplusObjects.AnalogOutput( AUTOCOOLSP__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( AUTOCOOLSP__AnalogSerialOutput__, AUTOCOOLSP );
    
    
    AUTOHEATSP_IN.OnAnalogChange.Add( new InputChangeHandlerWrapper( AUTOHEATSP_IN_OnChange_0, false ) );
    HEATUP.OnDigitalPush.Add( new InputChangeHandlerWrapper( AUTOHEATSP_IN_OnChange_0, false ) );
    AUTOCOOLSP_IN.OnAnalogChange.Add( new InputChangeHandlerWrapper( AUTOCOOLSP_IN_OnChange_1, false ) );
    COOLDOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( AUTOCOOLSP_IN_OnChange_1, false ) );
    DEADBAND.OnAnalogChange.Add( new InputChangeHandlerWrapper( DEADBAND_OnChange_2, false ) );
    RUN.OnDigitalPush.Add( new InputChangeHandlerWrapper( DEADBAND_OnChange_2, false ) );
    DUALAUTOMODE.OnDigitalPush.Add( new InputChangeHandlerWrapper( DEADBAND_OnChange_2, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public CrestronModuleClass_MAINTAINDEADBAND_EX ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint DUALAUTOMODE__DigitalInput__ = 0;
const uint HEATUP__DigitalInput__ = 1;
const uint COOLDOWN__DigitalInput__ = 2;
const uint RUN__DigitalInput__ = 3;
const uint DEADBAND__AnalogSerialInput__ = 0;
const uint AUTOHEATSP_IN__AnalogSerialInput__ = 1;
const uint AUTOCOOLSP_IN__AnalogSerialInput__ = 2;
const uint COOLMAX__AnalogSerialInput__ = 3;
const uint HEATMIN__AnalogSerialInput__ = 4;
const uint AUTOHEATSP__AnalogSerialOutput__ = 0;
const uint AUTOCOOLSP__AnalogSerialOutput__ = 1;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort LASTCHANGED = 0;
            [SplusStructAttribute(1, false, true)]
            public ushort G_SEMAPHORE = 0;
            
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
