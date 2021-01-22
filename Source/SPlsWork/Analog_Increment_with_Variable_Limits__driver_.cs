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

namespace CrestronModule_ANALOG_INCREMENT_WITH_VARIABLE_LIMITS__DRIVER_
{
    public class CrestronModuleClass_ANALOG_INCREMENT_WITH_VARIABLE_LIMITS__DRIVER_ : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput DIUP;
        Crestron.Logos.SplusObjects.DigitalInput DIDOWN;
        Crestron.Logos.SplusObjects.DigitalInput DIMUTE;
        Crestron.Logos.SplusObjects.AnalogInput AIINCREMENT;
        Crestron.Logos.SplusObjects.AnalogInput AILOWERLIMIT;
        Crestron.Logos.SplusObjects.AnalogInput AIUPPERLIMIT;
        Crestron.Logos.SplusObjects.AnalogInput AIMUTELEVEL;
        Crestron.Logos.SplusObjects.AnalogOutput AOLEVEL;
        ushort G_IPREVIOUSLEVEL = 0;
        int G_SLILOWERLIMIT = 0;
        private void DOINCREMENT (  SplusExecutionContext __context__, ushort UPORDOWN ) 
            { 
            int TEMP = 0;
            
            
            __context__.SourceCodeLine = 53;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( AOLEVEL  .Value > AIUPPERLIMIT  .UshortValue ))  ) ) 
                { 
                __context__.SourceCodeLine = 56;
                AOLEVEL  .Value = (ushort) ( AIUPPERLIMIT  .UshortValue ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 58;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( AOLEVEL  .Value < AILOWERLIMIT  .UshortValue ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 61;
                    AOLEVEL  .Value = (ushort) ( AILOWERLIMIT  .UshortValue ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 65;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UPORDOWN == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 67;
                        TEMP = (int) ( (AOLEVEL  .Value + AIINCREMENT  .IntValue) ) ; 
                        __context__.SourceCodeLine = 68;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TEMP > AIUPPERLIMIT  .UshortValue ))  ) ) 
                            {
                            __context__.SourceCodeLine = 69;
                            TEMP = (int) ( AIUPPERLIMIT  .IntValue ) ; 
                            }
                        
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 73;
                        TEMP = (int) ( (AOLEVEL  .Value - AIINCREMENT  .IntValue) ) ; 
                        __context__.SourceCodeLine = 74;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TEMP < G_SLILOWERLIMIT ))  ) ) 
                            {
                            __context__.SourceCodeLine = 75;
                            TEMP = (int) ( AILOWERLIMIT  .IntValue ) ; 
                            }
                        
                        } 
                    
                    __context__.SourceCodeLine = 79;
                    AOLEVEL  .Value = (ushort) ( Functions.LowWord( (uint)( TEMP ) ) ) ; 
                    } 
                
                }
            
            
            }
            
        object DIUP_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 85;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DIMUTE  .Value == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 86;
                    DOINCREMENT (  __context__ , (ushort)( 0 )) ; 
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object DIDOWN_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 91;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DIMUTE  .Value == 0))  ) ) 
                {
                __context__.SourceCodeLine = 92;
                DOINCREMENT (  __context__ , (ushort)( 1 )) ; 
                }
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object DIMUTE_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 98;
        G_IPREVIOUSLEVEL = (ushort) ( AOLEVEL  .Value ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DIMUTE_OnRelease_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 103;
        AOLEVEL  .Value = (ushort) ( G_IPREVIOUSLEVEL ) ; 
        __context__.SourceCodeLine = 105;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DIUP  .Value == 1))  ) ) 
            {
            __context__.SourceCodeLine = 106;
            DOINCREMENT (  __context__ , (ushort)( 0 )) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 107;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DIDOWN  .Value == 1))  ) ) 
                {
                __context__.SourceCodeLine = 108;
                DOINCREMENT (  __context__ , (ushort)( 1 )) ; 
                }
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object AILOWERLIMIT_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 113;
        G_SLILOWERLIMIT = (int) ( AILOWERLIMIT  .IntValue ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}


public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    DIUP = new Crestron.Logos.SplusObjects.DigitalInput( DIUP__DigitalInput__, this );
    m_DigitalInputList.Add( DIUP__DigitalInput__, DIUP );
    
    DIDOWN = new Crestron.Logos.SplusObjects.DigitalInput( DIDOWN__DigitalInput__, this );
    m_DigitalInputList.Add( DIDOWN__DigitalInput__, DIDOWN );
    
    DIMUTE = new Crestron.Logos.SplusObjects.DigitalInput( DIMUTE__DigitalInput__, this );
    m_DigitalInputList.Add( DIMUTE__DigitalInput__, DIMUTE );
    
    AIINCREMENT = new Crestron.Logos.SplusObjects.AnalogInput( AIINCREMENT__AnalogSerialInput__, this );
    m_AnalogInputList.Add( AIINCREMENT__AnalogSerialInput__, AIINCREMENT );
    
    AILOWERLIMIT = new Crestron.Logos.SplusObjects.AnalogInput( AILOWERLIMIT__AnalogSerialInput__, this );
    m_AnalogInputList.Add( AILOWERLIMIT__AnalogSerialInput__, AILOWERLIMIT );
    
    AIUPPERLIMIT = new Crestron.Logos.SplusObjects.AnalogInput( AIUPPERLIMIT__AnalogSerialInput__, this );
    m_AnalogInputList.Add( AIUPPERLIMIT__AnalogSerialInput__, AIUPPERLIMIT );
    
    AIMUTELEVEL = new Crestron.Logos.SplusObjects.AnalogInput( AIMUTELEVEL__AnalogSerialInput__, this );
    m_AnalogInputList.Add( AIMUTELEVEL__AnalogSerialInput__, AIMUTELEVEL );
    
    AOLEVEL = new Crestron.Logos.SplusObjects.AnalogOutput( AOLEVEL__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( AOLEVEL__AnalogSerialOutput__, AOLEVEL );
    
    
    DIUP.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIUP_OnPush_0, false ) );
    DIDOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIDOWN_OnPush_1, false ) );
    DIMUTE.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIMUTE_OnPush_2, false ) );
    DIMUTE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( DIMUTE_OnRelease_3, false ) );
    AILOWERLIMIT.OnAnalogChange.Add( new InputChangeHandlerWrapper( AILOWERLIMIT_OnChange_4, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public CrestronModuleClass_ANALOG_INCREMENT_WITH_VARIABLE_LIMITS__DRIVER_ ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint DIUP__DigitalInput__ = 0;
const uint DIDOWN__DigitalInput__ = 1;
const uint DIMUTE__DigitalInput__ = 2;
const uint AIINCREMENT__AnalogSerialInput__ = 0;
const uint AILOWERLIMIT__AnalogSerialInput__ = 1;
const uint AIUPPERLIMIT__AnalogSerialInput__ = 2;
const uint AIMUTELEVEL__AnalogSerialInput__ = 3;
const uint AOLEVEL__AnalogSerialOutput__ = 0;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
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
