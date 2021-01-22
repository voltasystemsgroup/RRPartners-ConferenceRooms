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

namespace UserModule_BOOT_V1_11
{
    public class UserModuleClass_BOOT_V1_11 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        Crestron.Logos.SplusObjects.DigitalInput FIRST_BOOT_RESET;
        Crestron.Logos.SplusObjects.DigitalOutput PRE_BOOT;
        Crestron.Logos.SplusObjects.DigitalOutput FIRST_BOOT;
        Crestron.Logos.SplusObjects.DigitalOutput FIRST_BOOT_COMPLETED_FB;
        Crestron.Logos.SplusObjects.DigitalOutput BOOT;
        object FIRST_BOOT_RESET_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 14;
                FIRST_BOOT_COMPLETED_FB  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 15;
                _SplusNVRAM.SBOOTFIRST  .UpdateValue ( ""  ) ; 
                
                
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
            
            __context__.SourceCodeLine = 20;
            Functions.Pulse ( 1, PRE_BOOT ) ; 
            __context__.SourceCodeLine = 22;
            WaitForInitializationComplete ( ) ; 
            __context__.SourceCodeLine = 24;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.SBOOTFIRST != "I Have Booted For The First Time Already!!"))  ) ) 
                { 
                __context__.SourceCodeLine = 26;
                Functions.Pulse ( 1, FIRST_BOOT ) ; 
                __context__.SourceCodeLine = 27;
                FIRST_BOOT_COMPLETED_FB  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 28;
                _SplusNVRAM.SBOOTFIRST  .UpdateValue ( "I Have Booted For The First Time Already!!"  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 32;
                FIRST_BOOT_COMPLETED_FB  .Value = (ushort) ( 1 ) ; 
                } 
            
            __context__.SourceCodeLine = 35;
            Functions.Pulse ( 1, BOOT ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        SocketInfo __socketinfo__ = new SocketInfo( 1, this );
        InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
        _SplusNVRAM = new SplusNVRAM( this );
        _SplusNVRAM.SBOOTFIRST  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        FIRST_BOOT_RESET = new Crestron.Logos.SplusObjects.DigitalInput( FIRST_BOOT_RESET__DigitalInput__, this );
        m_DigitalInputList.Add( FIRST_BOOT_RESET__DigitalInput__, FIRST_BOOT_RESET );
        
        PRE_BOOT = new Crestron.Logos.SplusObjects.DigitalOutput( PRE_BOOT__DigitalOutput__, this );
        m_DigitalOutputList.Add( PRE_BOOT__DigitalOutput__, PRE_BOOT );
        
        FIRST_BOOT = new Crestron.Logos.SplusObjects.DigitalOutput( FIRST_BOOT__DigitalOutput__, this );
        m_DigitalOutputList.Add( FIRST_BOOT__DigitalOutput__, FIRST_BOOT );
        
        FIRST_BOOT_COMPLETED_FB = new Crestron.Logos.SplusObjects.DigitalOutput( FIRST_BOOT_COMPLETED_FB__DigitalOutput__, this );
        m_DigitalOutputList.Add( FIRST_BOOT_COMPLETED_FB__DigitalOutput__, FIRST_BOOT_COMPLETED_FB );
        
        BOOT = new Crestron.Logos.SplusObjects.DigitalOutput( BOOT__DigitalOutput__, this );
        m_DigitalOutputList.Add( BOOT__DigitalOutput__, BOOT );
        
        
        FIRST_BOOT_RESET.OnDigitalPush.Add( new InputChangeHandlerWrapper( FIRST_BOOT_RESET_OnPush_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_BOOT_V1_11 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint FIRST_BOOT_RESET__DigitalInput__ = 0;
    const uint PRE_BOOT__DigitalOutput__ = 0;
    const uint FIRST_BOOT__DigitalOutput__ = 1;
    const uint FIRST_BOOT_COMPLETED_FB__DigitalOutput__ = 2;
    const uint BOOT__DigitalOutput__ = 3;
    
    [SplusStructAttribute(-1, true, false)]
    public class SplusNVRAM : SplusStructureBase
    {
    
        public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
        
        [SplusStructAttribute(0, false, true)]
            public CrestronString SBOOTFIRST;
            
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
