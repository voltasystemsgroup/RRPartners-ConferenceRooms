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

namespace CrestronModule_TSTAT_TEMP_DISPLAY_V1_1
{
    public class CrestronModuleClass_TSTAT_TEMP_DISPLAY_V1_1 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.AnalogInput TEMPERATURE_IN_TENTHS;
        Crestron.Logos.SplusObjects.DigitalInput SHOW_HALF_DEGREES;
        Crestron.Logos.SplusObjects.DigitalInput HIDE_VALUE;
        Crestron.Logos.SplusObjects.StringInput APPEND_CHARS;
        Crestron.Logos.SplusObjects.StringOutput TEMPERATURE_DISPLAY__DOLLAR__;
        private ushort ROUNDEDDIVIDE (  SplusExecutionContext __context__, ushort IOPERAND , ushort IDIVISOR ) 
            { 
            ushort IQUOTIENT = 0;
            ushort IREMAINDER = 0;
            
            
            __context__.SourceCodeLine = 38;
            IQUOTIENT = (ushort) ( (IOPERAND / IDIVISOR) ) ; 
            __context__.SourceCodeLine = 39;
            IREMAINDER = (ushort) ( Mod( IOPERAND , IDIVISOR ) ) ; 
            __context__.SourceCodeLine = 41;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IREMAINDER < (IDIVISOR / 2) ))  ) ) 
                {
                __context__.SourceCodeLine = 42;
                return (ushort)( IQUOTIENT) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 44;
                return (ushort)( (IQUOTIENT + 1)) ; 
                }
            
            
            return 0; // default return value (none specified in module)
            }
            
        private void UPDATEDISPLAY (  SplusExecutionContext __context__ ) 
            { 
            ushort IINTPART = 0;
            ushort IFRACPART = 0;
            
            
            __context__.SourceCodeLine = 51;
            if ( Functions.TestForTrue  ( ( Functions.Not( SHOW_HALF_DEGREES  .Value ))  ) ) 
                { 
                __context__.SourceCodeLine = 53;
                TEMPERATURE_DISPLAY__DOLLAR__  .UpdateValue ( Functions.ItoA (  (int) ( ROUNDEDDIVIDE( __context__ , (ushort)( TEMPERATURE_IN_TENTHS  .UshortValue ) , (ushort)( 10 ) ) ) ) + APPEND_CHARS  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 58;
                IINTPART = (ushort) ( (TEMPERATURE_IN_TENTHS  .UshortValue / 10) ) ; 
                __context__.SourceCodeLine = 59;
                IFRACPART = (ushort) ( Mod( TEMPERATURE_IN_TENTHS  .UshortValue , 10 ) ) ; 
                __context__.SourceCodeLine = 61;
                switch ((int)IFRACPART)
                
                    { 
                    case 0 : 
                    case 1 : 
                    case 2 : 
                    case 3 : 
                    
                        { 
                        __context__.SourceCodeLine = 68;
                        IFRACPART = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 69;
                        break ; 
                        } 
                    
                    goto case 4 ;
                    case 4 : 
                    goto case 5 ;
                    case 5 : 
                    goto case 6 ;
                    case 6 : 
                    
                        { 
                        __context__.SourceCodeLine = 76;
                        IFRACPART = (ushort) ( 5 ) ; 
                        __context__.SourceCodeLine = 77;
                        break ; 
                        } 
                    
                    goto case 7 ;
                    case 7 : 
                    goto case 8 ;
                    case 8 : 
                    goto case 9 ;
                    case 9 : 
                    
                        { 
                        __context__.SourceCodeLine = 84;
                        IFRACPART = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 85;
                        IINTPART = (ushort) ( (IINTPART + 1) ) ; 
                        __context__.SourceCodeLine = 86;
                        break ; 
                        } 
                    
                    break;
                    } 
                    
                
                __context__.SourceCodeLine = 90;
                TEMPERATURE_DISPLAY__DOLLAR__  .UpdateValue ( Functions.ItoA (  (int) ( IINTPART ) ) + "." + Functions.ItoA (  (int) ( IFRACPART ) ) + APPEND_CHARS  ) ; 
                } 
            
            
            }
            
        object TEMPERATURE_IN_TENTHS_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 98;
                if ( Functions.TestForTrue  ( ( Functions.Not( HIDE_VALUE  .Value ))  ) ) 
                    {
                    __context__.SourceCodeLine = 99;
                    UPDATEDISPLAY (  __context__  ) ; 
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object HIDE_VALUE_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 104;
            TEMPERATURE_DISPLAY__DOLLAR__  .UpdateValue ( ""  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object HIDE_VALUE_OnRelease_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 109;
        UPDATEDISPLAY (  __context__  ) ; 
        
        
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
        
        __context__.SourceCodeLine = 114;
        APPEND_CHARS  .UpdateValue ( ""  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    SHOW_HALF_DEGREES = new Crestron.Logos.SplusObjects.DigitalInput( SHOW_HALF_DEGREES__DigitalInput__, this );
    m_DigitalInputList.Add( SHOW_HALF_DEGREES__DigitalInput__, SHOW_HALF_DEGREES );
    
    HIDE_VALUE = new Crestron.Logos.SplusObjects.DigitalInput( HIDE_VALUE__DigitalInput__, this );
    m_DigitalInputList.Add( HIDE_VALUE__DigitalInput__, HIDE_VALUE );
    
    TEMPERATURE_IN_TENTHS = new Crestron.Logos.SplusObjects.AnalogInput( TEMPERATURE_IN_TENTHS__AnalogSerialInput__, this );
    m_AnalogInputList.Add( TEMPERATURE_IN_TENTHS__AnalogSerialInput__, TEMPERATURE_IN_TENTHS );
    
    APPEND_CHARS = new Crestron.Logos.SplusObjects.StringInput( APPEND_CHARS__AnalogSerialInput__, 2, this );
    m_StringInputList.Add( APPEND_CHARS__AnalogSerialInput__, APPEND_CHARS );
    
    TEMPERATURE_DISPLAY__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TEMPERATURE_DISPLAY__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TEMPERATURE_DISPLAY__DOLLAR____AnalogSerialOutput__, TEMPERATURE_DISPLAY__DOLLAR__ );
    
    
    TEMPERATURE_IN_TENTHS.OnAnalogChange.Add( new InputChangeHandlerWrapper( TEMPERATURE_IN_TENTHS_OnChange_0, false ) );
    SHOW_HALF_DEGREES.OnDigitalChange.Add( new InputChangeHandlerWrapper( TEMPERATURE_IN_TENTHS_OnChange_0, false ) );
    HIDE_VALUE.OnDigitalPush.Add( new InputChangeHandlerWrapper( HIDE_VALUE_OnPush_1, false ) );
    HIDE_VALUE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( HIDE_VALUE_OnRelease_2, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public CrestronModuleClass_TSTAT_TEMP_DISPLAY_V1_1 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint TEMPERATURE_IN_TENTHS__AnalogSerialInput__ = 0;
const uint SHOW_HALF_DEGREES__DigitalInput__ = 0;
const uint HIDE_VALUE__DigitalInput__ = 1;
const uint APPEND_CHARS__AnalogSerialInput__ = 1;
const uint TEMPERATURE_DISPLAY__DOLLAR____AnalogSerialOutput__ = 0;

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
